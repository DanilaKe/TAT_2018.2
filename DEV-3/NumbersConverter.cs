using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEV_3
{
    /// <summary>
    /// 
    /// </summary>
    public class NumbersConverter
    {
        private int NumberInDecimal { get; set; }
        private int Basis { get; set; }
        
        // 
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
        
        public string ConvertNumberFromDecimal(int receivedNumber, int basisOfTheNewNumberSystem)
        {
            
            NumberInDecimal = Math.Abs(receivedNumber);
            if (basisOfTheNewNumberSystem < 1 || basisOfTheNewNumberSystem > 20)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            Basis = basisOfTheNewNumberSystem;

            StringBuilder convertedReversibleString = new StringBuilder();
            int addedElement;
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
            
            var returnedNumber = new string(convertedReversibleString.ToString().Reverse().ToArray());

            return returnedNumber;
        }
    }
}