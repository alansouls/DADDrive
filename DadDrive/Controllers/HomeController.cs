using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using DadDrive.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using BlobServices.Services;

namespace DadDrive.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBlobService _blobService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _blobService = new BlobService("DefaultEndpointsProtocol=https;AccountName=daddiag204;AccountKey=90FXksIHbRcw7Tnq0LKpnMXVcmwPFVOLBbuFtLAJIDHrnSgsGuB08wy1S9eK+TfMDGnCFAdRY3IMZ7KM4Fm+TQ==;EndpointSuffix=core.windows.net");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    _blobService.SelectBlobContainer("images");
                    _blobService.UploadFile(fileBytes, "images");
                }
            }
            return Ok();
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
    }
}
