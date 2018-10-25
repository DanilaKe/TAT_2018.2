using System;
using System.Collections.Generic;
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
        private int NumberInDecimal { get; set; }
        private int Basis { get; set; }
        // Matching numbers with letters.
        private readonly string lettersInNumbers = "0123456789ABCDEFGHIJ";

        public NumbersConverter(int receivedNumber, int basisOfTheNewNumberSystem)
        {
            if (basisOfTheNewNumberSystem < 2 || basisOfTheNewNumberSystem > 20)
            {
                throw new ArgumentOutOfRangeException("Basis is not in the desired range.");
            }

            NumberInDecimal = receivedNumber;
            Basis = basisOfTheNewNumberSystem;
        }

        /// <summary>
        /// Method ConvertNumberFromDecimal
        /// Converting a number in the decimal number system to another system.
        /// </summary>
        /// <param name="receivedNumber">Received number in decimal system.</param>
        /// <param name="basisOfTheNewNumberSystem">Resived basis</param>
        /// <returns>Converted number</returns>
        public string ConvertNumberFromDecimal()
        {
            string returnedNumber;
            if (NumberInDecimal == 0)
            {
                returnedNumber = "0";
                return returnedNumber;
            }
            
            bool negativeNumber = NumberInDecimal < 0;
            
            NumberInDecimal = Math.Abs(NumberInDecimal);

            StringBuilder convertedReversibleString = new StringBuilder();

            // Loop that divides the number on the basis of the new number system.
            while (NumberInDecimal > 0)
            {
                var addedElement = NumberInDecimal % Basis;
                if (addedElement < 10)
                {
                    convertedReversibleString.Append(addedElement);
                }
                else
                {
                    convertedReversibleString.Append(lettersInNumbers[addedElement]);
                }

                NumberInDecimal /= Basis;
            }

            if (negativeNumber)
            {
                convertedReversibleString.Append('-');
            }
            
            // Flips a string.
            returnedNumber = new string(convertedReversibleString.ToString().Reverse().ToArray());

            return returnedNumber;
        }
    }
}