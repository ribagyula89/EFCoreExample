using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EFCoreExample.Client;

namespace EFCoreExample.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddBaseAddressHttpClient();

            builder.RootComponents.Add<App>("app");

            builder.Services.AddBlazoredSessionStorage();

            await builder.Build().RunAsync();
        }
    }
}