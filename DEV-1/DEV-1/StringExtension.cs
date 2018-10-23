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
            var maximumLength = 0;
            
            if (sequenceOfSymbols.Length == 1)
            {
                maximumLength = 1;    
                return maximumLength;
            }
            
            // Check string for the full uniqueness of characters.
            var stringWithoutDuplicates = sequenceOfSymbols.Distinct();
            if (sequenceOfSymbols.Length == stringWithoutDuplicates.Count())
            {
                maximumLength = sequenceOfSymbols.Length;
                return maximumLength;
            }

            var listOfUniqueCharacters = new List<char>();

            for (var i = 0; i < sequenceOfSymbols.Length; i++)
            { 
                // Loop to search for a unique subsequence.
                foreach (var j in sequenceOfSymbols.Skip(i))
                {
                    if (listOfUniqueCharacters.Contains(j))
                    {
                        break;
                    }

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