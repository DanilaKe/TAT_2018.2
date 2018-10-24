using System;
using System.Collections.Generic;

namespace DEV_4
{
    internal class EntryPoint
    {
        public static void Main(string[] args)
        {
            try
            {
                var XmlToStringConverter = new FileToStringConverter(args[0]);
                string xmlToString = XmlToStringConverter.ReturnedString;
                
                var xmlParser = new XmlParser(xmlToString);
                List<string> parsedResult = xmlParser.Parsing();

                var Sorter = new ArgumentSorter(parsedResult);
                List<string> parsedsortedResult = Sorter.Sort();
                
                foreach (var i in parsedsortedResult)
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