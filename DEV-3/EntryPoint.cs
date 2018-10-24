using System;

namespace DEV_3
{
    /// <summary>
    /// Class EntryPoint
    /// Receives a decimal number and a basis and translates the number into the selected basis.
    /// </summary>
    internal class EntryPoint
    {
        /// <summary>
        /// Method Main
        /// Entry point.
        /// </summary>
        /// <param name="args">Arguments from the command line, the first argument is the number
        /// in decimal notation, the second argument is the basis.</param>
        /// <exception cref="WrongNumberOfArgumentsException">Thrown when there is not two argument on the command line.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when not getting two integers as arguments</exception>
        public static void Main(string[] args)
        {
            try
            {
                // Check that only two arguments were received.
                if (args.Length != 2)
                {
                    if (args.Length == 0)
                    {
                        throw new WrongNumberOfArgumentsException("You have not used any arguments in the console line.");
                    }
                    
                    throw new WrongNumberOfArgumentsException($"You used {args.Length} arguments instead of 2 argument.");
                }

                if (!int.TryParse(args[0], out var receivedNumber) || !int.TryParse(args[1], out var receivedBasis))
                {
                    throw new ArgumentOutOfRangeException("Arguments entered incorrectly.");
                }
            
                var numbersConverter = new NumbersConverter();
                string convertedNumber = numbersConverter.ConvertNumberFromDecimal(receivedNumber, receivedBasis);
                
                Console.WriteLine($"Number in decimal : {receivedNumber}");
                Console.WriteLine($"Converted number (basis {receivedBasis}) : {convertedNumber}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
        }
    }
}