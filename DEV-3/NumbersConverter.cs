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
        private Dictionary<int, char> LettersInNumbers = new Dictionary<int, char> 
        {
            [10] = 'A',
            [11] = 'B',
            [12] = 'C',
            [13] = 'D',
            [14] = 'E',
            [15] = 'F',
            [16] = 'G',
            [17] = 'H',
            [18] = 'I',
            [19] = 'J'    
        };
        
        /// <summary>
        /// Method ConvertNumberFromDecimal
        /// Converting a number in the decimal number system to another system.
        /// </summary>
        /// <param name="receivedNumber">Received number in decimal system.</param>
        /// <param name="basisOfTheNewNumberSystem">Resived basis</param>
        /// <returns>Converted number</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the basis is not in the desired range.</exception>
        public string ConvertNumberFromDecimal(int receivedNumber, int basisOfTheNewNumberSystem)
        {
            
            NumberInDecimal = Math.Abs(receivedNumber);
            if (basisOfTheNewNumberSystem < 2 || basisOfTheNewNumberSystem > 20)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            Basis = basisOfTheNewNumberSystem;

            StringBuilder convertedReversibleString = new StringBuilder();
            int addedElement;
            
            // Loop that divides the number on the basis of the new number system.
            while (NumberInDecimal > 0)
            {
                addedElement = NumberInDecimal % Basis;
                if (addedElement < 10)
                {
                    convertedReversibleString.Append(addedElement);
                }
                else
                {
                    convertedReversibleString.Append(LettersInNumbers[addedElement]);
                }

                NumberInDecimal /= Basis;
            }

            if (receivedNumber < 0)
            {
                convertedReversibleString.Append('-');
            }
            
            // Flips a string.
            var returnedNumber = new string(convertedReversibleString.ToString().Reverse().ToArray());

            return returnedNumber;
        }
    }
}