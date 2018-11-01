namespace DEV_5
{
    public class Count : ICatalogCommand
    {
        private Catalog catalog;
        private bool ThisIsCountTypes;

        public Count(Catalog receivedCatalog, bool thisIsCountTypes = false)
        {
            catalog = receivedCatalog;
            ThisIsCountTypes = thisIsCountTypes;
        }


        public void Execute()
        {
            if (ThisIsCountTypes)
            {
                catalog.Count(this, ThisIsCountTypes);
            }
            else
            {
                catalog.Count(this);
            }
        }
    }
}