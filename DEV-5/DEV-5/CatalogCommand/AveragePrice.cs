namespace DEV_5
{
    public class AveragePrice : ICatalogCommand
    {
        private Catalog catalog;

        public AveragePrice(Catalog receivedCatalog)
        {
            catalog = receivedCatalog;
        }

        public void Execute()
        {
            catalog.AveragePrice(this);
        }
    }
}