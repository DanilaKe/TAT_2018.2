namespace DEV_8
{
    /// <summary>
    /// This command is engaged in a call of a method of calculation
    /// of the average price, in the chosen catalog.
    /// </summary>
    public class AveragePrice : ICatalogCommand
    {
        private readonly Receiver catalog;

        public AveragePrice(Receiver receivedCatalog)
        {
            catalog = receivedCatalog;
        }

        public void Execute()
        {
            catalog.AveragePrice();
        }
    }
}