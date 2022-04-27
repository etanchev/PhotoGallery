using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGallery.HelperClasses
{
    public static class JSInterOpExtentions
    {
        public static ValueTask<string> CopyToClipboard(this IJSRuntime jsRuntime, string text)
        {
            return jsRuntime.InvokeAsync<string>("clipboardCopy.copyText", text);
        }

    }
}
