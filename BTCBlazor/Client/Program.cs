using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BTCBlazor.Client.Services;

namespace BTCBlazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            //builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri("") });
            builder.Services.AddHttpClient<IExchangeRatesService, ExchangeRatesService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));


            await builder.Build().RunAsync();
        }
    }
}
