namespace DEV_8
{
    /// <summary>
    /// This command is engaged in calling the method of counting the number of cars in the selected catalog.
    /// </summary>
    public class CountAllCommand : ICatalogCommand
    {
        private readonly IReceiver Catalog;

        public CountAllCommand(IReceiver receivedCatalog)
        {
            Catalog = receivedCatalog;
        }

        public void Execute()
        {
            Catalog.Count();
        }
    }
}