using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace stonk
{
    public class Base
    {
        public static void Main(string[] args)
        {
            DotEnv.Load();
            Console.WriteLine(Environment.GetEnvironmentVariable("APCA_API_KEY_ID"));
            
            
        }
    }
}

