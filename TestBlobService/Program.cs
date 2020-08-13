using BlobServices.Services;
using BlobServices.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestBlobService
{
    class Program
    {
        static string MyAccountConnectionString = "DefaultEndpointsProtocol=https;AccountName=fdinhadiag;AccountKey=GaubV943eZmd71z8G3g8Qx0+x6+daBJPl2XK5YXjV8LxR5YwYLvlJURVehK2YfI/uc2YfkVkd7Rz4ipfwJd4fQ==;EndpointSuffix=core.windows.net";
        static void Main(string[] args)
        {
            IBlobService service = new BlobService(MyAccountConnectionString);

            service.SelectBlobContainer("teste");
            IEnumerable<BlobFile> result = service.ListFiles();
            foreach (var f in result)
            {
                Console.WriteLine("File Full Name: " + f.FullName);
                Console.WriteLine("File Name: " + f.Name);
                Console.WriteLine("File Folder: " + f.Folder);
                Console.WriteLine("File URI: " + f.Uri);
            }
        }
    }
}
