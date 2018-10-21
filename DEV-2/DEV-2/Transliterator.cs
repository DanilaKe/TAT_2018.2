using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEV_2
{
    /// <summary>
    /// Class Transliterator
    /// Makes a string transliteration.
    /// </summary>
    public class Transliterator
    {
        /// <summary>
        /// Method Transliteration
        /// Makes transliteration depending on the type of alphabet.
        /// </summary>
        /// <param name="receivedString">String, which was inputed<</param>
        /// <returns>Transliterated string.</returns>
        public string Transliteration(string receivedString)
        {
            TypeOfText typeOfString = GetTypeOfString(receivedString.ToLower());
            string transliteratedString = CyrillicLatinTransliteration(receivedString,typeOfString);
            
            return transliteratedString;
        }
        
        /// <summary>
        /// Method GetTypeOfString
        /// Gets string and finds out type of string.
        /// </summary>
        /// <param name="receivedString">String, which was inputed<</param>
        /// <returns>Type of string</returns>
        /// <exception cref="UndefinedStringTypeException">Thrown when unable to find out the type of string.</exception>
        private TypeOfText GetTypeOfString(string receivedString)
        {
            var cyrillicCharFlag = false; // A variable that signals when the Cyrillic alphabet is in a string.
            TypeOfText returnedType = TypeOfText.Cyrillic; 
            
            var stringWithoutLatinCharacter = receivedString.Where(x => !Enumerable.Range(97, 122).Contains(x)).Select(x => x);
            if (stringWithoutLatinCharacter.Any(x => Enumerable.Range(1072, 1103).Contains(x)))
            {
                cyrillicCharFlag = true;
                returnedType = TypeOfText.Cyrillic;
            }
            
            var stringWithoutCyrillicCharacter = receivedString.Where(x => !Enumerable.Range(1072, 1103).Contains(x)).Select(x => x);
            if (stringWithoutCyrillicCharacter.Any(x => Enumerable.Range(97, 122).Contains(x)))
            {
                // Throw when have Latin and Cyrillic alphabet.
                if (cyrillicCharFlag)
                {
                    throw new UndefinedStringTypeException("Cannot determine string type.");
                }
                returnedType = TypeOfText.Latin;
            }
    
            return returnedType;
        }
        
        /// <summary>
        /// Method CyrillicLatinTransliteration
        /// Transliterates Cyrillic into Latin or Latin into Cyrillic, depending on the type of string.
        /// </summary>
        /// <returns>Transliterated string</returns>
        private string CyrillicLatinTransliteration(string receivedString, TypeOfText typeOfString)
        {
            StringBuilder transliteratedString = new StringBuilder(receivedString.ToLower());

            if (typeOfString == TypeOfText.Cyrillic)
            {
                foreach (var i in cyrillicLatinDictionary.Keys)
                {
                    transliteratedString.Replace(i, cyrillicLatinDictionary[i]);
                }
            }
            
            if (typeOfString == TypeOfText.Latin)
            {
                foreach (var i in cyrillicLatinDictionary.Keys)
                {
                    if (cyrillicLatinDictionary[i] != string.Empty)
                    {
                        transliteratedString.Replace(cyrillicLatinDictionary[i], i);
                    }
                }
            }

            return transliteratedString.ToString(); 
        }
        
        /// <summary>
        /// Dictionary cyrillicLatinDictionary
        /// The correspondence between the Cyrillic and Latin alphabet.
        /// </summary>
        private readonly Dictionary<string, string> cyrillicLatinDictionary = new Dictionary<string, string>
        {
            ["щ"] = "sch",
            ["ё"] = "yo",
            ["ж"] = "zh",
            ["х"] = "kh",
            ["ц"] = "ts",
            ["ч"] = "ch",
            ["ш"] = "sh",
            ["ю"] = "yu",
            ["я"] = "ya",
            ["а"] = "a",
            ["б"] = "b",
            ["в"] = "v",
            ["г"] = "g",
            ["д"] = "d",
            ["е"] = "e",
            ["з"] = "z",
            ["и"] = "i",
            ["й"] = "y",
            ["к"] = "k",
            ["л"] = "l",
            ["м"] = "m",
            ["н"] = "n",
            ["о"] = "o",
            ["п"] = "p",
            ["р"] = "r",
            ["с"] = "s",
            ["т"] = "t",
            ["у"] = "u",
            ["ф"] = "f",
            ["ъ"] = string.Empty,
            ["ы"] = "y",
            ["ь"] = string.Empty,
            ["э"] = "e",
        };
    }
}