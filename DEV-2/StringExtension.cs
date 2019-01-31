namespace DEV_2
{
    public static class StringExtension
    {
        /// <summary>
        /// Method GetTranslit
        /// Makes transliteration of the received string.
        /// </summary>
        /// <param name="receivedString">String, which was inputed</param>
        /// <returns>Transliterated string</returns>
        public static string GetTranslit(this string receivedString)
        {
            var cyrillicLatinTransliterator = new Transliterator();
            string transliteratedString = cyrillicLatinTransliterator.Transliteration(receivedString);
            
            return transliteratedString;
        }
    }
}