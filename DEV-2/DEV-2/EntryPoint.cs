using System;

namespace DEV_2
{
    internal class EntryPoint
    {
        public static void Main(string[] args)
        {
            try
            {
                string transliteratedString = args[0].GetTranslit();
                Console.WriteLine(transliteratedString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}