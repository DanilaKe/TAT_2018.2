using System;

namespace DEV_3
{
    /// <summary>
    /// 
    /// </summary>
    internal class EntryPoint
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            try
            {
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
                    throw new ArgumentOutOfRangeException("");
                }
            
                var numbersConverter = new NumbersConverter();
                string convertedNumber = numbersConverter.ConvertNumberFromDecimal(receivedNumber, receivedBasis);
                
                Console.WriteLine($"Number in decimal : {receivedNumber}");
                Console.WriteLine($"Converted number (basis {receivedBasis}) : {convertedNumber}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}