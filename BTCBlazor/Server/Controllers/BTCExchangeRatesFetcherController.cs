using BTCBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text.Json;

namespace BTCBlazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BTCExchangeRatesFetcherController : ControllerBase
    {
        private static readonly string apiUrl = "https://blockchain.info/ticker";

        private readonly ILogger<BTCExchangeRatesFetcherController> logger;

        public BTCExchangeRatesFetcherController(ILogger<BTCExchangeRatesFetcherController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public Currencies Get()
        {

            var exchangeRates = JsonSerializer.Deserialize<Currencies>(apiUrl);

            return exchangeRates;

        }
    }
}
