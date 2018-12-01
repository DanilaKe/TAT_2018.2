namespace DEV_8
{
    /// <summary>
    /// This command is engaged in calling the method of counting the number of cars in the selected catalog.
    /// </summary>
    public class CountAll : ICatalogCommand
    {
        private readonly Receiver catalog;

        public CountAll(Receiver receivedCatalog)
        {
            catalog = receivedCatalog;
        }

        public void Execute()
        {
            catalog.Count();
        }
    }
}