using System;
using System.Collections.Generic;
using System.IO;

namespace stonk
{
    public static class DotEnv
    {
        public static void Load()
        {
            // possibly null, leaving it as-is for readability
            string pathToProjectRoot = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string pathToFile = pathToProjectRoot +  "/apca.env";
            Dictionary<string,string> env_vars = new Dictionary<string,string>();
            
            try
            {
                StreamReader sr = new StreamReader(pathToFile);
                var line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    env_vars.Add(line.Split("=")[0],line.Split("=")[1]);
                    
                    //Read the next line
                    line = sr.ReadLine();
                }
                sr.Close();
                // Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error setting environment variables in DotEnv.cs");
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
                foreach (KeyValuePair<string, string> env_var_pair in env_vars)
                {
                    Environment.SetEnvironmentVariable(env_var_pair.Key,env_var_pair.Value);
                }

            }
        }
    }
}