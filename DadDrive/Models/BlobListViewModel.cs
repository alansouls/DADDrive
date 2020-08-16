using BlobServices.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DadDrive.Models
{
    public class BlobListViewModel
    {
        public IEnumerable<BlobFile> Blobs { get; set; }
    }
}
