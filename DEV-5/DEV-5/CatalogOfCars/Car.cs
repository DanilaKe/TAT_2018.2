using System;

namespace DEV_5
{
    /// <summary>
    /// Class Car
    /// Information about cars of the same brand and their number.
    /// </summary>
    public class Car
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int NumberOfCars { get; private set; }
        public double Price { get; private set; }
        
        public Car(object CallingClass,string brand, string model, int numberOfCars, double price)
        {
            // Check on the creation of a new car only from the catalog.
            if (!(CallingClass is Catalog))
            {
                throw new Exception("An attempt to create an object of the class Car is not in Catalog.");
            }
            
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