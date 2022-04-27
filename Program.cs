using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PhotoGallery.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

#if DEBUG

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001") });

#else
                builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://client.PhotoGallery.photography") });
#endif

            // Configure your authentication provider options here.
            // For more information, see https://aka.ms/blazor-standalone-auth
            // builder.Configuration.Bind("oidc_google", options.ProviderOptions); 
            builder.Services.AddOidcAuthentication(options =>
            {
               
#if DEBUG

                builder.Configuration.Bind("oidc_localhost", options.ProviderOptions);
                options.UserOptions.RoleClaim = "role";  //in order to read the role claim and apply the AutorizeView Roles atribute 

#else

                  builder.Configuration.Bind("oidc_PhotoGalleryIdentityServer", options.ProviderOptions);
                  options.UserOptions.RoleClaim = "role";
#endif
            });

            builder.Services.AddHttpClient();
#if DEBUG
            builder.Services.AddHttpClient("UnauthorizedAPI", o =>
            {
                o.BaseAddress = new Uri("https://localhost:6001");


            });        

            // Register a named HttpClient here for the API
            builder.Services.AddHttpClient("PhotoGalleryCoreAPI", o =>
            {
                o.BaseAddress = new Uri("https://localhost:6001");
                //o.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "http://client.PhotoGallery.photography");

            })
            .AddHttpMessageHandler(sp =>
            {
               
                var handler = sp.GetService<AuthorizationMessageHandler>()
                    .ConfigureHandler(
                        authorizedUrls: new[] { "https://localhost:6001" },
                        scopes: new[] { "PhotoGallery_api" }
                        );

                return handler;
            });


#else
            builder.Services.AddHttpClient("UnauthorizedAPI", o =>
            {
                o.BaseAddress = new Uri("https://api.PhotoGallery.photography");


            });  

            builder.Services.AddHttpClient("PhotoGalleryCoreAPI", o => {
                o.BaseAddress = new Uri("https://api.PhotoGallery.photography");

            }).AddHttpMessageHandler(sp =>
            {
                var handler = sp.GetService<AuthorizationMessageHandler>()
                    .ConfigureHandler(
                        authorizedUrls: new[] { "https://api.PhotoGallery.photography" },
                        scopes: new[] { "PhotoGallery_api" }
                        );
                return handler;
            });
#endif

            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddScoped<ApiCalls>();

            await builder.Build().RunAsync();
        }
    }
}
