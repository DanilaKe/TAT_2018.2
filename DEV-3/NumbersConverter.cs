using System;
using System.Linq;
using System.Text;

namespace DEV_3
{
    /// <summary>
    /// Class NumberConverter.
    /// Converting a number in the decimal number system to another system.
    /// </summary>
    public class NumbersConverter
    {
        private int radix;
        private int numberInDecimal;
        private const int MaxRadix = 20;
        private const int MinRadix = 2;
        
        public int Radix
        {
            get => radix;

            set
            {
                if (value < MinRadix || value > MaxRadix)
                {
                    throw new ArgumentOutOfRangeException("Radix is not in the desired range.");
                }

                radix = value;
            }
        }
        
        public int NumberInDecimal
        {
            get => numberInDecimal;

            set
            {
                if (value == int.MinValue)
                {
                    throw new ArgumentOutOfRangeException("Number in decimal is not in the desired range.");
                }

                numberInDecimal = value;
            }
        }
        
        // Matching numbers with letters.
        private readonly string lettersInNumbers = "0123456789ABCDEFGHIJ";

        public NumbersConverter()
        {
            NumberInDecimal = 0;
            Radix = MinRadix;
        }
        
        public NumbersConverter(int receivedNumber, int radixOfTheNewNumberSystem)
        {
            if (radixOfTheNewNumberSystem < MinRadix || radixOfTheNewNumberSystem > MaxRadix)
            {
                throw new ArgumentOutOfRangeException("Radix is not in the desired range.");
            }

            NumberInDecimal = receivedNumber;
            Radix = radixOfTheNewNumberSystem;
        }

        /// <summary>
        /// Method ConvertNumberFromDecimal
        /// Converting a number in the decimal number system to another system.
        /// </summary>
        /// <param name="receivedNumber">Received number in decimal system.</param>
        /// <param name="RadixOfTheNewNumberSystem">Resived basis</param>
        /// <returns>Converted number</returns>
        public string ConvertNumberFromDecimal()
        {
            if (NumberInDecimal == 0)
            {
                return "0";
            }

            if (Radix == 10)
            {
                return NumberInDecimal.ToString();
            }
            
            bool negativeNumber = NumberInDecimal < 0;
            
            NumberInDecimal = Math.Abs(NumberInDecimal);

            var convertedReversibleNumber = new StringBuilder();

            // Loop that divides the number on the basis of the new number system.
            while (NumberInDecimal > 0)
            {
                var addedElement = NumberInDecimal % Radix;
                NumberInDecimal /= Radix;
                convertedReversibleNumber.Append(lettersInNumbers[addedElement]);
            }

            if (negativeNumber)
            {
                convertedReversibleNumber.Append('-');
            }
            
            // Flips a string.
            var returnedNumber = new string(convertedReversibleNumber.ToString().Reverse().ToArray());

            return returnedNumber;
        }
    }
}