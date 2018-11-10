using System;

namespace DEV_6
{
    internal class EntryPoint
    {
        public static void Main(string[] args)
        {
            try
            {   
                JsonParser a = new JsonParser(args[0]);
                a.Parse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}