using System;
using System.Threading.Tasks;

namespace stonk

{
    internal static class Program
    {
        public static async Task Main()
        {
            Environment.SetEnvironmentVariable("APCA_SYMBOL","SPY");
            try
            {
                var testProcess = new GetHistoricalData();
                await testProcess.Run();
            }
            catch (Exception e)
            {
                await Console.Error.WriteLineAsync("Error in Program.cs: " + e);
            }
            // Console.Read();
        }
    }
}