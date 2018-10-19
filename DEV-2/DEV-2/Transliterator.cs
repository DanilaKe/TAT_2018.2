﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEV_2
{
    public class Transliterator
    {
        public string Transliteration(string sequenceOfSymbols)
        {
            TypeOfText typeOfString = GetTypeOfString(sequenceOfSymbols);
            Console.WriteLine(typeOfString);
            string transliteratedString = CyrillicLatinTransliteration(sequenceOfSymbols,typeOfString);
            return transliteratedString;
        }
        
        private TypeOfText GetTypeOfString(string sequenceOfSymbols)
        {
            try
            {
                var cyrillicCharFlag = false;
                TypeOfText returnedType = TypeOfText.Cyrillic;
                char minimalElement = (sequenceOfSymbols.Where(x => x != ' ').Select(y => y)).Min();
                char maximalElement = (sequenceOfSymbols.Where(x => x != ' ').Select(y => y)).Max();

                if (!((minimalElement >= (int)'a')  && (maximalElement <= (int)'z')))
                {
                    returnedType = TypeOfText.Cyrillic;
                    cyrillicCharFlag = true;
                }
                
                if (!((minimalElement >= (int)'а')  && (maximalElement <= (int)'я' || maximalElement == (int)'ё')))
                {
                    if (cyrillicCharFlag)
                    {
                        throw new Exception("  ");
                    }
                    
                    returnedType = TypeOfText.Latin;
                }

                return returnedType;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        
        private string CyrillicLatinTransliteration(string stringArgument, TypeOfText typeOfString)
        {
            StringBuilder transliteratedString = new StringBuilder();
            transliteratedString.Append(stringArgument);

            if (typeOfString == TypeOfText.Cyrillic)
            {
                foreach (var i in cyrillicLatinDictionary.Keys)
                {
                    transliteratedString.Replace(i, cyrillicLatinDictionary[i]);
                }
            }
            
            if (typeOfString == TypeOfText.Latin)
            {
                foreach (var i in latinCyrillicDictionary.Keys)
                {
                    transliteratedString.Replace(i, latinCyrillicDictionary[i]);
                }
            }

            return transliteratedString.ToString(); 
        }
        
        private readonly Dictionary<string, string> cyrillicLatinDictionary = new Dictionary<string, string>
        {
            ["а"] = "a",
            ["б"] = "b",
            ["в"] = "v",
            ["г"] = "g",
            ["д"] = "d",
            ["е"] = "e",
            ["ё"] = "yo",
            ["ж"] = "zh",
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
            ["х"] = "kh",
            ["ц"] = "ts",
            ["ч"] = "ch",
            ["ш"] = "sh",
            ["щ"] = "sch",
            ["ъ"] = string.Empty,
            ["ы"] = "y",
            ["ь"] = string.Empty,
            ["э"] = "e",
            ["ю"] = "yu",
            ["я"] = "ya"
        };
        
        private readonly Dictionary<string, string> latinCyrillicDictionary = new Dictionary<string, string>
        {
            ["a"] = "а",
            ["b"] = "б",
            ["v"] = "в",
            ["g"] = "г",
            ["d"] = "д",
            ["e"] = "е",
            ["yo"] = "ё",
            ["zh"] = "ж",
            ["z"] = "з",
            ["i"] = "и",
            ["iy"] = "й",
            ["k"] = "к",
            ["l"] = "л",
            ["m"] = "м",
            ["n"] = "н",
            ["o"] = "о",
            ["p"] = "п",
            ["r"] = "р",
            ["s"] = "с",
            ["t"] = "т",
            ["u"] = "у",
            ["f"] = "ф",
            ["kh"] = "х",
            ["ts"] = "ц",
            ["ch"] = "ч",
            ["sh"] = "ш",
            ["sch"] = "щ",
            ["y"] = "ы",
            ["ie"] = "э",
            ["yu"] = "ю",
            ["ya"] = "я"
        };
    }
}