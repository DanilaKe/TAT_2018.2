using System;

namespace DEV_5
{
    internal class EntryPoint
    {
        public static void Main(string[] args)
        {
            try
            {
                var commandHandler = new CommandHandler();
                commandHandler.RunCommandReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}