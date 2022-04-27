using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoGallery.Models
{
    public class ImageInfo : IImageInfo ,IBrowserFile
    {
        public string Base64Url { get; set; }
       

        public IBrowserFile File { get; set; }


        public string FileName { get; set; }

        public string Name => throw new NotImplementedException();

        public DateTimeOffset LastModified => throw new NotImplementedException();

        public long Size => throw new NotImplementedException();

        public string ContentType => throw new NotImplementedException();

        public bool IsLocalFile { get; set; }

        public Stream OpenReadStream(long maxAllowedSize = 512000, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
