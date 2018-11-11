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
                XmlParser a = new XmlParser(args[0]);
                List<string> b = a.Parse();
                foreach (var i in b)
                {
                    Console.WriteLine(i);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}