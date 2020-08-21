using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BTCBlazor.Shared
{
    public class BTCExchangeRates
    {
        [JsonPropertyName("15m")]
        public double Last15MinutesDelayed { get; set; }
        public double Last { get; set; }
        public double Buy { get; set; }
        public double Sell { get; set; }
        public string Symbol { get; set; }


    }

}
