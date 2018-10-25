using System;
using System.Collections.Generic;

namespace DEV_4
{
    /// <summary>
    /// Class EntryPoint
    /// Receives the address of the xml file from the
    /// command line, parses it and sorts by arguments.
    /// </summary>
    internal class EntryPoint
    {
        /// <summary>
        /// Method Main
        /// Entry point.
        /// </summary>
        ///<param name="args">Address of the xml file from the command line</param>
        public static void Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                {
                    throw new WrongNumberOfArgumentsException("Wrong number of arguments.");
                }
                
                if (args[0] == string.Empty)
                {
                    throw new ArgumentNullException("Empty argument");
                }
                
                // Convert the file to a string.
                var XmlToStringConverter = new FileToStringConverter(args[0]);
                string xmlToString = XmlToStringConverter.ReturnedString;
                
                // Parsing the received string.
                var xmlParser = new XmlParser(xmlToString);
                List<string> parsedResult = xmlParser.Parsing();

                // Sort by arguments.
                var Sorter = new ArgumentSorter(parsedResult);
                List<string> parsedsortedResult = Sorter.Sort();
                
                foreach (var i in parsedsortedResult)
                {
                    Console.WriteLine(i);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
        }
    }
}