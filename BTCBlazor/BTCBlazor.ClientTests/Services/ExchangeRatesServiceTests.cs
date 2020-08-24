using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichardSzalay.MockHttp;
using System.Net.Http;
using System.Threading.Tasks;
using Shouldly;


namespace BTCBlazor.Shared.Services.Tests
{
    [TestClass()]
    public class ExchangeRatesServiceTests
    {
        private MockHttpMessageHandler _mockHttp;
        private HttpClient _httpClient;
        private IExchangeRatesService _exchangeRatesService;


        [TestMethod()]
        public async Task GetAUDCurrencyTest()
        {
            // ARRANGE

            _mockHttp = new MockHttpMessageHandler();
            _mockHttp.When("https://blockchain.info/ticker")
    .Respond("application/json", "{  'USD' : { '15m' : 11831.79, 'last' : 11831.79, 'buy' : 11831.79, 'sell' : 11831.79, 'symbol' : '$'},  'AUD' : { '15m' : 16570.28, 'last' : 16570.28, 'buy' : 16570.28, 'sell' : 16570.28, 'symbol' : '$'},  'BRL' : { '15m' : 66723.01, 'last' : 66723.01, 'buy' : 66723.01, 'sell' : 66723.01, 'symbol' : 'R$'},  'CAD' : { '15m' : 15663.17, 'last' : 15663.17, 'buy' : 15663.17, 'sell' : 15663.17, 'symbol' : '$'},  'CHF' : { '15m' : 10790.83, 'last' : 10790.83, 'buy' : 10790.83, 'sell' : 10790.83, 'symbol' : 'CHF'},  'CLP' : { '15m' : 9323450.12, 'last' : 9323450.12, 'buy' : 9323450.12, 'sell' : 9323450.12, 'symbol' : '$'},  'CNY' : { '15m' : 81918.58, 'last' : 81918.58, 'buy' : 81918.58, 'sell' : 81918.58, 'symbol' : '¥'},  'DKK' : { '15m' : 74579.2, 'last' : 74579.2, 'buy' : 74579.2, 'sell' : 74579.2, 'symbol' : 'kr'},  'EUR' : { '15m' : 10013.34, 'last' : 10013.34, 'buy' : 10013.34, 'sell' : 10013.34, 'symbol' : '€'},  'GBP' : { '15m' : 9038.8, 'last' : 9038.8, 'buy' : 9038.8, 'sell' : 9038.8, 'symbol' : '£'},  'HKD' : { '15m' : 91698.85, 'last' : 91698.85, 'buy' : 91698.85, 'sell' : 91698.85, 'symbol' : '$'},  'INR' : { '15m' : 888541.34, 'last' : 888541.34, 'buy' : 888541.34, 'sell' : 888541.34, 'symbol' : '₹'},  'ISK' : { '15m' : 1628764.14, 'last' : 1628764.14, 'buy' : 1628764.14, 'sell' : 1628764.14, 'symbol' : 'kr'},  'JPY' : { '15m' : 1253978.11, 'last' : 1253978.11, 'buy' : 1253978.11, 'sell' : 1253978.11, 'symbol' : '¥'},  'KRW' : { '15m' : 1.407527426E7, 'last' : 1.407527426E7, 'buy' : 1.407527426E7, 'sell' : 1.407527426E7, 'symbol' : '₩'},  'NZD' : { '15m' : 18225.98, 'last' : 18225.98, 'buy' : 18225.98, 'sell' : 18225.98, 'symbol' : '$'},  'PLN' : { '15m' : 43995.02, 'last' : 43995.02, 'buy' : 43995.02, 'sell' : 43995.02, 'symbol' : 'zł'},  'RUB' : { '15m' : 874753.78, 'last' : 874753.78, 'buy' : 874753.78, 'sell' : 874753.78, 'symbol' : 'RUB'},  'SEK' : { '15m' : 103727.15, 'last' : 103727.15, 'buy' : 103727.15, 'sell' : 103727.15, 'symbol' : 'kr'},  'SGD' : { '15m' : 16216.59, 'last' : 16216.59, 'buy' : 16216.59, 'sell' : 16216.59, 'symbol' : '$'},  'THB' : { '15m' : 372228.1, 'last' : 372228.1, 'buy' : 372228.1, 'sell' : 372228.1, 'symbol' : '฿'},  'TRY' : { '15m' : 86903.49, 'last' : 86903.49, 'buy' : 86903.49, 'sell' : 86903.49, 'symbol' : '₺'},  'TWD' : { '15m' : 348114.93, 'last' : 348114.93, 'buy' : 348114.93, 'sell' : 348114.93, 'symbol' : 'NT$'}}".Replace("'", "\""));

            _httpClient = new HttpClient(_mockHttp);
            _exchangeRatesService = new ExchangeRatesService(_httpClient);

            //ACT
            var currencyCodes = await _exchangeRatesService.GetCurrencyCodes();


            //ASSERT

            currencyCodes.ShouldSatisfyAllConditions
        (
            () => currencyCodes.AUD.Last15MinutesDelayed.ShouldNotBeNull(),
            () => currencyCodes.AUD.Last.ShouldNotBeNull(),
            () => currencyCodes.AUD.Buy.ShouldNotBeNull(),
            () => currencyCodes.AUD.Sell.ShouldNotBeNull(),
            () => currencyCodes.AUD.Symbol.ShouldNotBeNull()
        ); 

        }
    }
}