using System;

namespace DEV_5
{
    internal class EntryPoint
    {
        public static void Main(string[] args)
        {
            try
            {
                var printer = new Printer();
                var catalogOfCar = new Catalog(printer.AddedCarHandler, printer.CountCarHandler, printer.AverageCarPriceHandler);
                var commandHandler = new CommandHandler(catalogOfCar, printer);
                commandHandler.RunCommandReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}