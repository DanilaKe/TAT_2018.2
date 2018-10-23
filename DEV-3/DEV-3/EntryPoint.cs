using System;

namespace DEV_3
{
    internal class EntryPoint
    {
        public static void Main(string[] args)
        {
            NumbersConverter a = new NumbersConverter();
            Console.WriteLine(a.ConvertNumberFromDecimal(26515613, 20));
        }
    }
}