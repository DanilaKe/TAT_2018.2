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
        
        public AveragePrice(Catalog receivedCatalog, string brand)
        {
            catalog = receivedCatalog;
            Brand = brand;
        }

        public void Execute()
        {
            if (Brand.Equals(string.Empty))
            {
                catalog.AveragePrice(this);
            }
            else
            {
                catalog.AveragePrice(this, Brand);
            }
        }
    }
}