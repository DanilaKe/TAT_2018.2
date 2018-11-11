using System;
using System.Collections.Generic;

namespace DEV_6
{
    internal class EntryPoint
    {
        public static void Main(string[] args)
        {
            try
            {   
                JsonParser a = new JsonParser(args[0]);
                List<string> b = a.Parse();
                foreach (var i in b)
                {
                    Console.WriteLine(i);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}