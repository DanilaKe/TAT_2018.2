namespace DEV_1
{
    public static class StringExtension
    {
        public static int GetLengthUniqueSubsequence(this string sequenceOfSymbols)
        {    
            var maxLength = 0;
            var characterCounter = 1;

            if (sequenceOfSymbols.Length == 1)
            {
                return 1;
            }

            for (var i = 1; i < sequenceOfSymbols.Length; i++)
            {
                if (sequenceOfSymbols[i - 1] != sequenceOfSymbols[i])
                {
                    ++characterCounter;
                }
                else
                {
                    characterCounter = 1;
                }

                if (characterCounter > maxLength)
                {
                    maxLength = characterCounter;
                }
            }

            return maxLength;
        }
    }
}