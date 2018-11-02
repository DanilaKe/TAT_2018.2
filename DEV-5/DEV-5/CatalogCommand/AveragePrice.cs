namespace DEV_5
{
    public class AveragePrice : ICatalogCommand
    {
        private Catalog catalog;
        private string Brand;

        public AveragePrice(Catalog receivedCatalog)
        {
            catalog = receivedCatalog;
            Brand = string.Empty;
        }

        public void Execute()
        {
            catalog.AveragePrice(this);
        }
    }
}