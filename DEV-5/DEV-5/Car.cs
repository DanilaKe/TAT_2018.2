using System;

namespace DEV_5
{
    public class Car
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int NumberOfCars { get; private set; }
        public double Price { get; private set; }
        
        public Car(object CallingClass,string brand, string model, int numberOfCars, double price)
        {
            if (!(CallingClass is Catalog))
            {
                throw new Exception("An attempt to create an object of the class Car is not in Catalog.");
            }
            
            Brand = brand;
            Model = model;
            NumberOfCars = numberOfCars;
            Price = price;
        }
    }
}