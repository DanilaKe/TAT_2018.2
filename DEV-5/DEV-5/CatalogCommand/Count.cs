namespace DEV_5
{
    public class Count : ICatalogCommand
    {
        private Catalog catalog;
        private bool thisIsCountTypes;

        public Count(Catalog receivedCatalog)
        {
            catalog = receivedCatalog;
            thisIsCountTypes = false;
        }
        
        public Count(Catalog receivedCatalog, string type)
        {
            catalog = receivedCatalog;
            thisIsCountTypes = true;
        }


        public void Execute()
        {
            if (thisIsCountTypes)
            {
                catalog.Count(this, string.Empty);
            }
            else
            {
                catalog.Count(this);
            }
        }
    }
}