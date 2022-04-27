using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGallery.Models
{
    public interface IImageInfo
    {
       
        public string FileName { get; set; }

        public IBrowserFile File { get; set; }
        public string Base64Url { get; set; }

        public bool IsLocalFile { get; set; }


    }
}
