using System;
using System.Collections.Generic;
using System.Text;

namespace BTCBlazor.Shared
{
    public class BTCExchangeRates
    {
        public decimal Last15MinutesDelayed { get; set; }
        public decimal Last { get; set; }
        public decimal Buy { get; set; }
        public decimal Sell { get; set; }
        public string Symbol { get; set; }


    }

}
