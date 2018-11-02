namespace DEV_5
{
    public class CountAll : ICatalogCommand
    {
        private Catalog catalog;

        public CountAll(Catalog receivedCatalog)
        {
            catalog = receivedCatalog;
        }

        public void Execute()
        {
            catalog.CountCars(this);
        }
    }
}