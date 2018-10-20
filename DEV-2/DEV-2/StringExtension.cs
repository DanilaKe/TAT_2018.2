namespace DEV_2
{
    public static class StringExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sequenceOfSymbols"></param>
        /// <returns></returns>
        public static string GetTranslit(this string sequenceOfSymbols)
        {
            var cyrillicLatinTransliterator = new Transliterator();
            string transliteratedString = cyrillicLatinTransliterator.Transliteration(sequenceOfSymbols);
            return transliteratedString;
        }
    }
}