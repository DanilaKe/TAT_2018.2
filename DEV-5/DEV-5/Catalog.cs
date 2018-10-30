using System;
using System.Collections.Generic;

namespace DEV_5
{
    public class Catalog
    {
        private List<Car> CatalogOfCar { get; set; }
        public int Counter { get; private set; }
        public int Capacity { get; private set; }
        
        public Catalog()
        {
            CatalogOfCar = new List<Car>();
            Counter = 0;
            // Capacity is not set, it means it is not limited (-1).
            Capacity = -1; 
        }
        
        public Catalog(int capacity)
        {
            CatalogOfCar = new List<Car>();
            Counter = 0;
            Capacity = capacity; 
        }

        public bool AddCar(string brand, string model, int numberOfCars, string price)
        {
            if ((Capacity < Counter + 1) && (Capacity != -1))
            {
                throw new Exception();
            }
            
            var AddedCar = new Car(this, brand, model, numberOfCars, price);
            CatalogOfCar.Add(AddedCar);
            Counter++;
            
        }

        public int Count(object CallingClass, string type)
        {
            if (!(CallingClass is CommandHandler))
            {
                throw new Exception();
            }
            
            // TODO
        }

        public int Count(object CallingClass)
        {
            if (!(CallingClass is CommandHandler))
            {
                throw new Exception();
            }
            
            // TODO
        }

        public int AveragePrice(object CallingClass)
        {
            if (!(CallingClass is CommandHandler))
            {
                throw new Exception();
            }
            
            // TODO
        }
        
        public int AveragePrice(object CallingClass, string type)
        {
            if (!(CallingClass is CommandHandler))
            {
                throw new Exception();
            }
            
            // TODO
        }
    }
}