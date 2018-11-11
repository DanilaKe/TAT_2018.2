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
                Parser parser = new XmlParser("empty");
                if (args[0].Contains(".xml"))
                {
                    parser = new JsonParser(args[0]);
                }

                if (args[0].Contains(".json"))
                {
                    parser = new JsonParser(args[0]);
                }

                var result = parser.Parse();
                foreach (var i in result)
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