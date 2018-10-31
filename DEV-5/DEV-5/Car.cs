using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DEV_5
{
    public class Car
    {
        public Car(object CallingClass,string brand, string model, int numberOfCars, int price)
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

        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int NumberOfCars { get; private set; }
        public int Price { get; private set; }
    }
}