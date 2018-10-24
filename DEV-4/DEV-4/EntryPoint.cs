using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
                Sorter.Sort();
                
                foreach (var i in parsedResult)
                {
                    foreach (var j in i)
                    {
                        Console.Write(j);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}