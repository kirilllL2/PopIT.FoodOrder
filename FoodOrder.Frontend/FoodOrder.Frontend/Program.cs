using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using FoodOrder.Frontend.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;

namespace FoodOrder.Frontend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped<CustomAuthenticationMessageHandler>();
            builder.Services.AddHttpClient("FoodOrderWebAPI", opt => opt.BaseAddress = new Uri("https://localhost:7001"))
                .AddHttpMessageHandler<CustomAuthenticationMessageHandler>();
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("FoodOrderWebAPI"));
            builder.Services.AddScoped(sp => new Client("https://localhost:7001", sp.GetService<HttpClient>()));
            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Local", options.ProviderOptions);
            });

            builder.Services.AddServices();

            await builder.Build().RunAsync();
        }
    }
    
    public class CustomAuthenticationMessageHandler : AuthorizationMessageHandler
    {
        public CustomAuthenticationMessageHandler(IAccessTokenProvider provder, NavigationManager nav) : base(provder, nav)
        {
            ConfigureHandler(new string[] { "https://localhost:7001"});
        }
    }
}