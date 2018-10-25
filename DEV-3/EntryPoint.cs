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
        public static void Main(string[] args)
        {
            try
            {
                // Check that only two arguments were received.
                if (args.Length != 2)
                {
                    throw new WrongNumberOfArgumentsException("Wrong number of arguments.");
                }

                if (!int.TryParse(args[0], out var receivedNumber) || !int.TryParse(args[1], out var receivedBasis))
                {
                    throw new ArgumentOutOfRangeException("Arguments entered incorrectly.");
                }
            
                var numbersConverter = new NumbersConverter(receivedNumber, receivedBasis);
                string convertedNumber = numbersConverter.ConvertNumberFromDecimal();
                
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