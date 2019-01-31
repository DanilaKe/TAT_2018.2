namespace DEV_8
{
    /// <summary>
    /// This command is engaged in calling the method of calculating
    /// the average price of the chosen brand in the selected catalog.
    /// </summary>
    public sealed class AveragePriceTypeCommand : ICatalogCommand
    {
        private readonly IReceiver Catalog;
        private readonly string Brand;
            
        public AveragePriceTypeCommand(IReceiver receivedCatalog, string brand)
        {
            Catalog = receivedCatalog;
            Brand = brand;
        }

        public void Execute()
        {
            Catalog.AveragePrice(Brand);
        }
    }
}