namespace DEV_5
{
    /// <summary>
    /// This command calls the brand counting method in the selected catalog.
    /// </summary>
    public class CountType : ICatalogCommand
    {
        private readonly Catalog catalog; 
        
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