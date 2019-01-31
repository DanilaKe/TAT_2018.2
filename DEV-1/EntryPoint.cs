using System;

namespace DEV_1
{
    /// <summary>
    /// Class EntryPoint
    /// Takes 1 argument from the command line and searches for the
    /// maximum size of a series of unique characters in a string.
    /// </summary>
    class EntryPoint
    {
        /// Method Main
        /// Entry point.
        /// <exception cref="WrongNumberOfArguments">Thrown when there is not one argument on the command line.</exception>
        /// <exception cref="WrongDataInString">Thrown when the single argument is empty.</exception>
        public static void Main(string[] args)
        {
            try
            {
                // Check whether the argument is the only one.
                if (1 != args.Length)
                {
                    if (0 == args.Length)
                    {
                        throw new WrongNumberOfArguments("You have not used any arguments in the console line.");
                    }
                    
                    throw new WrongNumberOfArguments($"You used {args.Length} arguments instead of 1 argument.");
                }

                // Select the first argument from the command line.
                var sequenceOfSymbols = args[0];
                
                Console.WriteLine($"Maximum size of a series of unique characters : {sequenceOfSymbols.GetLengthUniqueSubsequence()}");
            }
            catch (ApplicationException e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
        }
    }
}