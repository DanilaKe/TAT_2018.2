namespace DEV_8
{
    public abstract class Machine
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int NumberOfCars { get; private set; }
        public decimal Price { get; private set; }

        protected Machine(string brand, string model, int numberOfCars, decimal price)
        {   
            Brand = brand;
            Model = model;
            NumberOfCars = numberOfCars;
            Price = price;
        }
        
        /// <summary>
        /// Adding cars of the same model.
        /// </summary>
        public void AddCars(int addedCars)
        {
            NumberOfCars += addedCars;
        }
    }
}