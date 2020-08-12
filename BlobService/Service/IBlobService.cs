using System;
using System.Collections.Generic;
using System.Text;

namespace BlobServices.Services
{
    public interface IBlobService
    {
        void SelectBlobContainer(string container);

        void UploadFile(byte[] file, string fileName);

        byte[] RetrieveFile(string path);

        string ListFiles();
    }
}
