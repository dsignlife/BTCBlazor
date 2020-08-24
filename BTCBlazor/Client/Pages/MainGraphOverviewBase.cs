using BTCBlazor.Shared.Services;
using BTCBlazor.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace BTCBlazor.Client.Pages
{
    public class MainGraphOverviewBase : ComponentBase
    {
        [Inject]
        public IExchangeRatesService exchangeRatesService { get; set; }

        public Currencies CurrencyList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            CurrencyList = await exchangeRatesService.GetCurrencyCodes();
        }

        protected async void getLastest()
        {
            CurrencyList = await exchangeRatesService.GetLastestCurrencyCodes();

        }



    }
}
