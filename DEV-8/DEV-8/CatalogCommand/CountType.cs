namespace DEV_8
{
    /// <summary>
    /// This command calls the brand counting method in the selected catalog.
    /// </summary>
    public class CountType : ICatalogCommand
    {
        private readonly Receiver catalog; 
        
        public CountType(Receiver receivedCatalog)
        {
            catalog = receivedCatalog;
        }
        
        public void Execute()
        {
            catalog.CountBrand();
        }
    }
}