using BTCBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTCBlazor.Client.Services
{
    public interface IExchangeRatesService
    {
        Task<Currencies> GetCurrencyCodes();

        Task<Currencies> GetLastestCurrencyCodes();


    }
}
