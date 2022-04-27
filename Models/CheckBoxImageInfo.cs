using PhotoGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGallery.Models
{
    public class CheckBoxImageInfo
    {
        public IImageInfo ImageInfo { get; set; }
        public bool IsChecked { get; set; }
    }
}
