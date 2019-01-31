using System.Collections.Generic;
using System.Linq;

namespace DEV_8
{
    /// <summary>
    /// Class Catalog
    /// Engaged in the addition of new machines, and implements
    /// some methods for searching and counting.
    /// </summary>
    public class Catalog<T> : IReceiver
        where T : Machine
    {
        private List<T> ListOfMachines { get; set; }
        private static Catalog<T> instance;
        
        // Methods occurring after the event.
        private event CatalogStateHandler CountedEvent;
        private event CatalogStateHandler CountedTypeEvent;
        private event CatalogStateHandler CalculatedEvent;
        
        public static Catalog<T> getInstance(CatalogStateHandler counted = null,
            CatalogStateHandler countedType = null, CatalogStateHandler calculated = null)
        {
            return instance ?? (instance = new Catalog<T>(counted, countedType, calculated));
        }
        private Catalog(CatalogStateHandler counted,CatalogStateHandler countedType, CatalogStateHandler calculated)
        {
            ListOfMachines = new List<T>();
            CountedEvent += counted;
            CountedTypeEvent += countedType;
            CalculatedEvent += calculated;
        }
        
        public void Add(List<T> listOfMachines)
        {
            foreach (var i in listOfMachines)
            {
                ListOfMachines.Add(i);
            }
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
        /// Method CountBrand
        /// Counts the number of car brands.
        /// </summary>
        public void CountBrand()
        {
            var Count = ListOfMachines.GroupBy(x => x.Brand).Count();
            CallEvent(new CatalogEventArgs(Count), CountedTypeEvent);
        }
        
        /// <summary>
        /// Method CountCars
        /// Counts the number of cars.
        /// </summary>
        public void Count()
        {
            var Count = ListOfMachines.Select(x => x.NumberOfCars).Sum(y => y);
            CallEvent(new CatalogEventArgs(Count), CountedEvent);
        }

        /// <summary>
        /// Method AveragePrice
        /// Considers the average cost of the car.
        /// </summary>
        public void AveragePrice()
        {
            var price = ListOfMachines.Select(x => x.Price).Average(y => y);
            CallEvent(new CatalogEventArgs(price), CalculatedEvent);
        }
        
        /// <summary>
        /// Method AveragePrice
        /// Considers the average cost of a car of a certain brand.
        /// </summary>
        /// <param name="brand">required brand</param>
        public void AveragePrice(string brand)
        {
            var validBrand = ListOfMachines.Select(x => x.Brand).Contains(brand);
            if (validBrand)
            {
                var price = ListOfMachines.Where(x => x.Brand == brand).Select(x => x.Price).Average(y => y);
                CallEvent(new CatalogEventArgs(price), CalculatedEvent);
            }
            else
            {
                CallEvent(null, CalculatedEvent);
            }
        }
    }
}