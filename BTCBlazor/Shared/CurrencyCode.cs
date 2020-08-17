using System;
using System.Collections.Generic;
using System.Text;

namespace BTCBlazor.Shared
{
    public class CurrencyCode
    {
        public string Code { get; set; }
        public BTCExchangeRates exchangeRates { get; set; }
    }
}
