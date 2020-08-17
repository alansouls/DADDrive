using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using DadDrive.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using BlobServices.Services;
using Microsoft.VisualBasic;

namespace DadDrive.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBlobService _blobService;

        public HomeController(ILogger<HomeController> logger, IBlobService blobService)
        {
            _logger = logger;
            _blobService = blobService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    _blobService.SelectBlobContainer("images");
                    _blobService.UploadFile(fileBytes, file.FileName);
                }
            }
            return Redirect("ListBlobs");
        }

        public IActionResult List()
        {
            return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ListBlobs()
        {
            _blobService.SelectBlobContainer("images");
            var files = _blobService.ListFiles();
            var model = new BlobListViewModel();
            model.Blobs = files;

            return View(model);
        }
    }
}
