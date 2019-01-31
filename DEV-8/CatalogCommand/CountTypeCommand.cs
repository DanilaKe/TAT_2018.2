namespace DEV_8
{
    /// <summary>
    /// This command calls the brand counting method in the selected catalog.
    /// </summary>
    public class CountTypeCommand : ICatalogCommand
    {
        private readonly IReceiver Catalog; 
        
        public CountTypeCommand(IReceiver receivedCatalog)
        {
            Catalog = receivedCatalog;
        }
        
        public void Execute()
        {
            Catalog.CountBrand();
        }
    }
}