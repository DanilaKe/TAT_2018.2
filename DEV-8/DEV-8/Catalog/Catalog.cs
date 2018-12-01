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
    public class Catalog<T> : Receiver
        where T : Machine
    {
        private List<T> ListOfMachines { get; set; }
        
        // Methods occurring after the event.
        private event CatalogStateHandler Counted;
        private event CatalogStateHandler CountedType;
        private event CatalogStateHandler Calculated;
        
        public Catalog(CatalogStateHandler counted,CatalogStateHandler countedType, CatalogStateHandler calculated)
        {
            ListOfMachines = new List<T>();
            Counted += counted;
            CountedType += countedType;
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
        public void AddMachine(T machine)
        {
            ListOfMachines.Add(machine);
        }    
        
        /// <summary>
        /// Method CountBrand
        /// Counts the number of car brands.
        /// </summary>
        /// <param name="CallingClass">The object needed to check the correct call.</param>
        public void CountBrand()
        {
            var Count = ListOfMachines.GroupBy(x => x.Brand).Count();
            CallEvent(new CatalogEventArgs(Count), Counted);
        }
        
        /// <summary>
        /// Method CountCars
        /// Counts the number of cars.
        /// </summary>
        /// <param name="CallingClass">The object needed to check the correct call.</param>
        public void Count()
        {
            var Count = ListOfMachines.Select(x => x.NumberOfCars).Sum(y => y);
            CallEvent(new CatalogEventArgs(Count), Counted);
        }

        /// <summary>
        /// Method AveragePrice
        /// Considers the average cost of the car.
        /// </summary>
        /// <param name="CallingClass">The object needed to check the correct call.</param>
        public void AveragePrice()
        {
            var price = ListOfMachines.Select(x => x.Price).Average(y => y);
            CallEvent(new CatalogEventArgs(price), Calculated);
        }
        
        /// <summary>
        /// Method AveragePrice
        /// Considers the average cost of a car of a certain brand.
        /// </summary>
        /// <param name="CallingClass">The object needed to check the correct call.</param>
        /// <param name="brand">required brand</param>
        public void AveragePrice(string brand)
        {
            var validBrand = ListOfMachines.Select(x => x.Brand).Contains(brand);
            if (validBrand)
            {
                var price = ListOfMachines.Where(x => x.Brand == brand).Select(x => x.Price).Average(y => y);
                CallEvent(new CatalogEventArgs(price), Calculated);
            }
            else
            {
                CallEvent(null, Calculated);
            }
        }
    }
}