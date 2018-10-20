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
        /// <exception cref="WrongNumberOfArguments">Thrown when there is not one argument on the command line.</exception>
        /// <exception cref="WrongDataInString">Thrown when the single argument is empty.</exception>
        public static void Main(string[] args)
        {
            try
            {
                // Check whether the argument is the only one.
                if (args.Length != 1)
                {
                    if (args.Length == 0)
                    {
                        throw new WrongNumberOfArgumentsException("You have not used any arguments in the console line.");
                    }
                    
                    throw new WrongNumberOfArgumentsException($"You used {args.Length} arguments instead of 1 argument.");
                }
                // Select the first argument from the command line.
                var sequenceOfSymbols = args[0];
                
                // Checks the argument for correctness.     
                if (sequenceOfSymbols == string.Empty)
                {
                    throw new EmptyStringException("Empty argument.");
                }

                string transliteratedString = sequenceOfSymbols.GetTranslit();
                
                Console.WriteLine(transliteratedString);
            }
            catch (ApplicationException e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
        }
    }
}