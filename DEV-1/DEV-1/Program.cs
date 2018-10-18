using System;

namespace DEV_1
{
    /// <summary>
    /// Class MaximumNumberOfUnequalCharacters
    /// Takes 1 argument from the command line and searches for the
    /// maximum size of a series of unique characters in a string.
    /// </summary>
    internal class MaximumNumberOfUnequalCharacters
    {
        /// Entry point.
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
                        throw new WrongNumberOfArguments("You have not used any arguments in the console line.");
                    }
                    
                    throw new WrongNumberOfArguments($"You used {args.Length} arguments instead of 1 argument.");
                }

                // Select the first argument from the command line.
                var sequenceOfSymbols = args[0];
                
                // Checks the argument for correctness.     
                if (sequenceOfSymbols == "")
                {
                    throw new WrongDataInString("Empty argument.");
                }
                
                int lengthUniqueSubsequence = sequenceOfSymbols.GetLengthUniqueSubsequence();
                
                Console.WriteLine($"Maximum size of a series of unique characters : {lengthUniqueSubsequence}");
            }
            catch (ApplicationException e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
        }
    }
}