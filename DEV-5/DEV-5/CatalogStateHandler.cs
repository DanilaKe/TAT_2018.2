namespace DEV_5
{
    public delegate void CatalogStateHandler(object sender, CatalogEventArgs e);

    public class CatalogEventArgs
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int NumberOfCars { get; private set; }
        public double Price { get; private set; }
        public double Count { get; private set; }
        public bool ThisIsCountTypes { get; private set; }
        
        public CatalogEventArgs(int numberOfCars, double price,string brand, string model, int count)
        {
            NumberOfCars = numberOfCars;
            Price = price;
            Brand = brand;
            Model = model;
            Count = count;
        }
        
        public CatalogEventArgs(double price, string brand)
        {
            Price = price;
            Brand = brand;
        }
        
        public CatalogEventArgs(int numberOfCars, bool thisIsCountTypes = false)
        {
            ThisIsCountTypes = thisIsCountTypes;
            NumberOfCars = numberOfCars;
        }
        
        public CatalogEventArgs(double price)
        {
            Price = price;
        }
    }
}