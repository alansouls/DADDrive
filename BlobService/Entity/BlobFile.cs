using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlobServices.Entity
{
    public class BlobFile
    {
        public string FullName { get; }
        public string Folder { get; set; }
        public string Name { get;}
        public Uri Uri { get;}

        public BlobFile(Uri blobUri)
        {
            Name = ExtractName(blobUri);
            Uri = blobUri;
            Folder = ExtractFolder(blobUri);
            FullName = Folder + "/" + Name;
        }

        private string ExtractName(Uri uri)
        {
            var name = uri.LocalPath.Split("/").Last();
            return name;
        }

        private string ExtractFolder(Uri uri)
        {
            var paths = uri.LocalPath.Split("/");
            return string.Join("/", paths.Take(paths.Count() - 1).ToList());
        }
    }
}
