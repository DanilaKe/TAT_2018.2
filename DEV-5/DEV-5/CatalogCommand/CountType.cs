namespace DEV_5
{
    public class CountType : ICatalogCommand
    {
        private Catalog catalog; 
        
        public CountType(Catalog receivedCatalog)
        {
            catalog = receivedCatalog;
        }
        
        public void Execute()
        {
            catalog.CountBrand(this);
        }
    }
}