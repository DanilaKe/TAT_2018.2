using System.Collections.Generic;
using System.Linq;

namespace DEV_1
{
    public static class StringExtension
    {
        /// <summary>
        /// Method GetLengthUniqueSubsequence
        /// Searches maximum length of same serial symbols in the string.
        /// </summary>
        /// <param name="sequenceOfSymbols">String, which was inputed</param>
        /// <returns>Maximum length of same serial symbols in the string.</returns>
        public static int GetLengthUniqueSubsequence(this string sequenceOfSymbols)
        {    
            if (sequenceOfSymbols.Length == 1)
            {
                return 1;
            }

            var stringWithoutDuplicates = sequenceOfSymbols.Distinct();
            if (sequenceOfSymbols.Length == stringWithoutDuplicates.Count())
            {
                return sequenceOfSymbols.Length;
            }

            var maximumLength = 1;
            var listOfUniqueCharacters = new List<char>();

            for (var i = 0; i < sequenceOfSymbols.Length; i++)
            {
                listOfUniqueCharacters.Add(sequenceOfSymbols[i]);
                foreach (var j in sequenceOfSymbols.Skip(i+1))
                {
                    if (listOfUniqueCharacters.Contains(j))
                        break;
                    listOfUniqueCharacters.Add(j);
                }

                if (maximumLength < listOfUniqueCharacters.Count)
                {
                    maximumLength = listOfUniqueCharacters.Count;
                }
                
                listOfUniqueCharacters.Clear();
            }
            
            return maximumLength;
        }
    }
}