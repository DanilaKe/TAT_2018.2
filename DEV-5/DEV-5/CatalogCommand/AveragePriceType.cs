namespace DEV_5
{
    public class AveragePriceType : ICatalogCommand
    {
        private Catalog catalog;
        private string Brand;
            
        public AveragePriceType(Catalog receivedCatalog, string brand)
        {
            catalog = receivedCatalog;
            Brand = brand;
        }

        public void Execute()
        {
            catalog.AveragePrice(this, Brand);
        }
    }
}