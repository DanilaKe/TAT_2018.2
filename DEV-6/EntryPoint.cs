using System;

namespace DEV_6
{
    /// <summary>
    /// Class EntryPoint.
    /// Receives the address of the xml or json file
    /// from the command line, parses it.
    /// </summary>
    internal class EntryPoint
    {
        /// <summary>
        /// Method Main
        /// Entry point.
        /// </summary>
        /// <param name="args">Address of XML or JSON file.</param>
        public static void Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                {
                    throw new Exception("Wrong number of arguments.");
                }

                Parser parser = null;
                
                if (args[0].Contains(".xml"))
                {
                    parser = new XmlParser(args[0]);
                }
                
                if (args[0].Contains(".json"))
                {
                    parser = new JsonParser(args[0]);
                }

                var result = parser?.Parse();
                foreach (var i in result)
                {
                    Console.WriteLine(i);
                }
                /*9var resultToFileConverter = new ResultToFileConverter("result.txt");
                resultToFileConverter.Convert(result);*/
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}