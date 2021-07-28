using Alpaca.Markets;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace stonk
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal sealed class GetHistoricalData
    {
        // private const string APCA_API_KEY_ID = "not_loaded_yet";//loaded from DotEnv.cs
        // private const string APCA_API_SECRET_KEY = "not_loaded_yet";//loaded from DotEnv.cs
        private const string APCA_SYMBOL = "SPY";//load in Program.cs? pass as variable?
        // include day and time ranges as parameters?

        private IAlpacaDataClient alpacaDataClient;

        public async Task Run()
        {
            DotEnv.Load();
            String key_id = Environment.GetEnvironmentVariable("APCA_API_KEY_ID");
            String secret_key = Environment.GetEnvironmentVariable("APCA_API_SECRET_KEY");
            String symbol = APCA_SYMBOL;
            alpacaDataClient = Environments.Paper.
                GetAlpacaDataClient(new SecretKey (key_id, secret_key));
            
            //following naming convention in apca api
            // use nodatime
            var from = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("7/20/2021 4:00:00 AM"));
            var into = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("7/20/2021 4:30:00 PM"));

            var barSet = await alpacaDataClient.ListHistoricalBarsAsync(
                new HistoricalBarsRequest(
                    symbol, 
                    from, into, 
                    BarTimeFrame.Hour));
            var bars = barSet.Items;
            //timezone not controlled for daylight savings yet
            // TimeZoneInfo est_tz = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            foreach (var bar in bars)
            {
                // need to unpack the json objects somewhere
                // Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(DateTime.Parse(bar.Close.ToString()),est_tz));
                Console.WriteLine(bar.Close);
            }
            Console.WriteLine("Done with GetHistoricalData.cs");
        }
        
        public async void GetDay()
        {
            DotEnv.Load();
            String key_id = Environment.GetEnvironmentVariable("APCA_API_KEY_ID");
            String secret_key = Environment.GetEnvironmentVariable("APCA_API_SECRET_KEY");
            String symbol = APCA_SYMBOL;
            alpacaDataClient = Environments.Paper.
                GetAlpacaDataClient(new SecretKey (key_id, secret_key));
            
            //following naming convention in apca api
            // use nodatime
            var from = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("7/20/2021 4:00:00 AM"));
            var into = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("7/20/2021 4:30:00 PM"));

            var barSet = await alpacaDataClient.ListHistoricalBarsAsync(
                new HistoricalBarsRequest(
                    symbol, 
                    from, into, 
                    BarTimeFrame.Hour));
            var bars = barSet.Items;
            //timezone not controlled for daylight savings yet
            // TimeZoneInfo est_tz = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            foreach (var bar in bars)
            {
                // need to unpack the json objects somewhere
                // Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(DateTime.Parse(bar.Close.ToString()),est_tz));
                Console.WriteLine(bar.Close);
            }
            Console.WriteLine("Done with GetHistoricalData.cs");
        }
    }
}