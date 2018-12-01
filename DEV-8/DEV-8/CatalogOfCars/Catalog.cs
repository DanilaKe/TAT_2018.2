using System;
using System.Collections.Generic;
using System.Linq;

namespace DEV_8
{
    /// <summary>
    /// Class Catalog
    /// Engaged in the addition of new machines, and implements
    /// some methods for searching and counting.
    /// </summary>
    public class Catalog
    {
        private List<Car> CatalogOfCar { get; set; }
        public int Counter { get; private set; }
        public int Capacity { get; private set; }
        
        // Methods occurring after the event.
        private event CatalogStateHandler Added;
        private event CatalogStateHandler CountedCars;
        private event CatalogStateHandler CountedBrands;
        private event CatalogStateHandler Calculated;
        
        public Catalog(CatalogStateHandler added, CatalogStateHandler countedCars, CatalogStateHandler countedBrands, CatalogStateHandler calculated)
        {
            CatalogOfCar = new List<Car>();
            Counter = 0;
            // Capacity is not set, it means it is not limited (-1).
            Capacity = -1;
            Added += added;
            CountedCars += countedCars;
            CountedBrands += countedBrands;
            Calculated += calculated;
        }
        
        public Catalog(CatalogStateHandler added, CatalogStateHandler countedCars,CatalogStateHandler countedBrands , CatalogStateHandler calculated ,int capacity)
        {
            CatalogOfCar = new List<Car>();
            Counter = 0;
            Capacity = capacity; 
            Added += added;
            CountedCars += countedCars;
            CountedBrands += countedBrands;
            Calculated += calculated;
        }
        
        /// <summary>
        /// Method CallEvent
        /// Calls delegate passed.
        /// </summary>
        private void CallEvent(CatalogEventArgs e, CatalogStateHandler handler)
        {
            if ((handler != null) && (e != null))
            {
                handler(this, e);
            }
        }
        
        /// <summary>
        /// Method AddCar
        /// Adds a new car to the catalog or if it exists in
        /// the catalog complements the information.
        /// </summary>
        /// <param name="CallingClass">The object needed to check the correct call.</param>
        public void AddCar(object CallingClass, string brand, string model, int numberOfCars, double price)
        {
            if (!(CallingClass is ICatalogCommand))
            {
                throw new Exception("Attempting to access the catalog of cars without using the CatalogCommand.");
            }
            
            // Capacity check (if Capacity = -1, this means that capacity is unlimited).
            if ((Capacity < Counter + 1) && (Capacity != -1))
            {
                throw new Exception("Catalog overflow.");
            }

            var existingCar  = CatalogOfCar.Any(x => (x.Brand == brand) && (x.Model == model));
            if (!existingCar)
            {
                var AddedCar = new Car(this, brand, model, numberOfCars, price);
                CatalogOfCar.Add(AddedCar);
                Counter++;
                CallEvent(new CatalogEventArgs(numberOfCars, price, brand, model, Counter), Added);
            }
            else
            {
                var numberOfExistingCar = CatalogOfCar.First(x => (x.Brand == brand) && (x.Model == model));
                if (numberOfExistingCar.Price != price)
                {
                    throw new Exception("Incorrect input of an existing car.");
                }
                numberOfExistingCar.AddCars(numberOfCars);
            }
        }    
        
        /// <summary>
        /// Method CountBrand
        /// Counts the number of car brands.
        /// </summary>
        /// <param name="CallingClass">The object needed to check the correct call.</param>
        public void CountBrand(object CallingClass)
        {
            if (!(CallingClass is ICatalogCommand))
            {
                throw new Exception("Attempting to access the catalog of cars without using the CatalogCommand.");
            }

            var Count = CatalogOfCar.GroupBy(x => x.Brand).Count();
            CallEvent(new CatalogEventArgs(Count), CountedCars);
        }
        
        /// <summary>
        /// Method CountCars
        /// Counts the number of cars.
        /// </summary>
        /// <param name="CallingClass">The object needed to check the correct call.</param>
        public void CountCars(object CallingClass)
        {
            if (!(CallingClass is ICatalogCommand))
            {
                throw new Exception("Attempting to access the catalog of cars without using the CatalogCommand.");
            }
            
            var Count = CatalogOfCar.Select(x => x.NumberOfCars).Sum(y => y);
            CallEvent(new CatalogEventArgs(Count), CountedBrands);
        }

        /// <summary>
        /// Method AveragePrice
        /// Considers the average cost of the car.
        /// </summary>
        /// <param name="CallingClass">The object needed to check the correct call.</param>
        public void AveragePrice(object CallingClass)
        {
            if (!(CallingClass is ICatalogCommand))
            {
                throw new Exception("Attempting to access the catalog of cars without using the CatalogCommand.");
            }

            var price = CatalogOfCar.Select(x => x.Price).Average(y => y);
            CallEvent(new CatalogEventArgs(price), Calculated);
        }
        
        /// <summary>
        /// Method AveragePrice
        /// Considers the average cost of a car of a certain brand.
        /// </summary>
        /// <param name="CallingClass">The object needed to check the correct call.</param>
        /// <param name="brand">required brand</param>
        public void AveragePrice(object CallingClass, string brand)
        {
            if (!(CallingClass is ICatalogCommand))
            {
                throw new Exception("Attempting to access the catalog of cars without using the CatalogCommand.");
            }
    
            var validBrand = CatalogOfCar.Select(x => x.Brand).Contains(brand);
            if (validBrand)
            {
                var price = CatalogOfCar.Where(x => x.Brand == brand).Select(x => x.Price).Average(y => y);
                CallEvent(new CatalogEventArgs(price, brand), Calculated);
            }
            else
            {
                CallEvent(null, Calculated);
            }
        }
    }
}