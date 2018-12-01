namespace DEV_8
{
    /// <summary>
    /// This command is engaged in calling the method of calculating
    /// the average price of the chosen brand in the selected catalog.
    /// </summary>
    public class AveragePriceType : ICatalogCommand
    {
        private readonly Receiver catalog;
        private readonly string Brand;
            
        public AveragePriceType(Receiver receivedCatalog, string brand)
        {
            catalog = receivedCatalog;
            Brand = brand;
        }

        public void Execute()
        {
            catalog.AveragePrice(Brand);
        }
    }
}