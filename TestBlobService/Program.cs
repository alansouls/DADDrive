using BlobServices.Services;
using System;

namespace TestBlobService
{
    class Program
    {
        static string MyAccountConnectionString = "DefaultEndpointsProtocol=https;AccountName=fdinhadiag;AccountKey=GaubV943eZmd71z8G3g8Qx0+x6+daBJPl2XK5YXjV8LxR5YwYLvlJURVehK2YfI/uc2YfkVkd7Rz4ipfwJd4fQ==;EndpointSuffix=core.windows.net";
        static void Main(string[] args)
        {
            IBlobService service = new BlobService(MyAccountConnectionString);

            service.SelectBlobContainer("teste");
            var result = service.ListFiles();
            Console.WriteLine(result);
        }
    }
}
