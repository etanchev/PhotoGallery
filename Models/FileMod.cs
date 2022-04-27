using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGallery.Models
{
    public class FileMod
    {
        public string UrlBase64 { get; set; }
        public IBrowserFile ResizedFile { get; set; }
    }
}
