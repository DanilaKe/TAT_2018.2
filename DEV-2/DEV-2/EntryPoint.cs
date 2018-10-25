using System;

namespace DEV_2
{
    /// <summary>
    /// Class EntryPoint
    /// Takes 1 argument from the command line & makes a string transliteration.
    /// </summary>
    internal class EntryPoint
    {
        /// <summary>
        /// Method Main
        /// Entry point.
        /// </summary>
        public static void Main(string[] args)
        {
            try
            {
                // Check whether the argument is the only one.
                if (args.Length != 1)
                {
                    throw new WrongNumberOfArgumentsException("Wrong number of arguments.");
                }
                // Select the first argument from the command line.
                var sequenceOfSymbols = args[0];
                
                // Checks the argument for correctness.     
                if (sequenceOfSymbols == string.Empty)
                {
                    throw new EmptyStringException("Empty argument.");
                }

                string transliteratedString = sequenceOfSymbols.GetTranslit();
                Console.WriteLine($"{sequenceOfSymbols} --> {transliteratedString}");
            }
            catch (ApplicationException e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
        }
    }
}