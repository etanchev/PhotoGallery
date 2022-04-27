using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;
using PhotoGallery.Models;
using System;
using System.IO;

namespace PhotoGallery.Services
{
    public class ApiCalls
    {

        readonly private IHttpClientFactory _clientFactory;
        public ApiCalls(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;

        }


        public async Task<HttpResponseMessage> PostFolderCreation(Folder folder)
        {
            try
            {

                return await _clientFactory.CreateClient("PhotoGalleryCoreAPI").PostAsJsonAsync("/CreateFolder", folder);

            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }

        }

        public async Task<List<Folder>> GetFolders()
        {
            try
            {
                return await _clientFactory.CreateClient("PhotoGalleryCoreAPI")
                                       .GetFromJsonAsync<List<Folder>>("/GetFolders");

            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                return null;
            }
        }
        public async Task<HttpResponseMessage> DeleteFolder(int folderID)
        {
            try
            {

                return await _clientFactory.CreateClient("PhotoGalleryCoreAPI")
                                       .DeleteAsync($"/DeleteFolder/{folderID}");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }

        }

        public async Task<HttpResponseMessage> DeleteFile(string filePath, string fileName)
        {
            try
            {
                return await _clientFactory.CreateClient("PhotoGalleryCoreAPI")
                                       .DeleteAsync($"/DeleteFile/{filePath}/{fileName}");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
        }

        public async Task<HttpResponseMessage> UploadFile(HttpContent content, string dir, bool WaterMark)
        {
            try
            {
                return await _clientFactory.CreateClient("PhotoGalleryCoreAPI")
                                       .PostAsync($"/UploadFile/{dir}/{WaterMark}", content);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }

        }


        public async Task<List<IImageInfo>> GetImages(Guid dir)
        {
            try
            {

                var imageInfoList = await _clientFactory.CreateClient("PhotoGalleryCoreAPI")
                                      .GetFromJsonAsync<List<ImageInfo>>($"/GetImages/{dir}");

                List<IImageInfo> IImageInfo = new(imageInfoList);



                return IImageInfo;
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                return null;
            }
        }

        public async Task<IImageInfo> GetImageBase64(Guid dir, string filename)
        {
            try
            {

                var imageInfoList = await _clientFactory.CreateClient("PhotoGalleryCoreAPI")
                                   .GetFromJsonAsync<ImageInfo>($"/GetImageBase64/{dir}/{filename}");

                IImageInfo iImageInfo = imageInfoList;

                return iImageInfo;

            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                return null;
            }
        }
        public async Task<List<IImageInfo>> GetImagesUnauthorized(Guid dir)
        {
            try
            {

                var imageInfoList = await _clientFactory.CreateClient("UnauthorizedAPI")
                                      .GetFromJsonAsync<List<ImageInfo>>($"/GetImages/{dir}");

                List<IImageInfo> IImageInfo = new(imageInfoList);



                return IImageInfo;
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                return null;
            }
        }
        public async Task<string> GetWatermark()
        {
            try
            {
                return await _clientFactory.CreateClient("PhotoGalleryCoreAPI")
                                      .GetStringAsync("/GetWatermark");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                return null;
            }
        }

        public async Task<byte[]> GetImageStream(string dir, string fileName)
        {
            try
            {
                return await _clientFactory.CreateClient("PhotoGalleryCoreAPI")
                                      .GetByteArrayAsync($"/GetImageStream/{dir}/{fileName}");

            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                return null;
            }
        }

        public async Task<HttpResponseMessage> UploadWaterMark(HttpContent content)
        {
            try
            {
                return await _clientFactory.CreateClient("PhotoGalleryCoreAPI")
                                       .PostAsync("/UploadWaterMark", content);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }

        }

        public async Task<HttpResponseMessage> PostEmail(EmailModelBlazor emailModelBlazor)
        {
            try
            {

                string jsons = JsonSerializer.Serialize(emailModelBlazor).ToString();
                return await _clientFactory.CreateClient("UnauthorizedAPI")
                                       .PostAsync($"/EmailSender/EmailFromBlazor", new StringContent(jsons, Encoding.UTF8, "application/json"));


                // return await _clientFactory.CreateClient("UnauthorizedAPI").PostAsJsonAsync($"/EmailSender/EmailFromBlazor", emailModelBlazor);

            }
            catch
            {

                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }

        }


    }
}
