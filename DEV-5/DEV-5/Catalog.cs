using System;
using System.Collections.Generic;
using System.Linq;

namespace DEV_5
{
    public class Catalog
    {
        private List<Car> CatalogOfCar { get; set; }
        public int Counter { get; private set; }
        public int Capacity { get; private set; }
        
        protected event CatalogStateHandler Added;
        protected event CatalogStateHandler Counted;
        protected event CatalogStateHandler Calculated;
        
        public Catalog(CatalogStateHandler added, CatalogStateHandler counted, CatalogStateHandler calculated)
        {
            CatalogOfCar = new List<Car>();
            Counter = 0;
            // Capacity is not set, it means it is not limited (-1).
            Capacity = -1;
            Added += added;
            Counted += counted;
            Calculated += calculated;
        }
        
        public Catalog(CatalogStateHandler added, CatalogStateHandler counted, CatalogStateHandler calculated ,int capacity)
        {
            CatalogOfCar = new List<Car>();
            Counter = 0;
            Capacity = capacity; 
            Added += added;
            Counted += counted;
            Calculated += calculated;
        }
        
        private void CallEvent(CatalogEventArgs e, CatalogStateHandler handler)
        {
            if (handler != null && e!=null)
                handler(this, e);
        }
        
        public void AddCar(string brand, string model, int numberOfCars, double price)
        {
            if ((Capacity < Counter + 1) && (Capacity != -1))
            {
                throw new Exception();
            }
            
            var AddedCar = new Car(this, brand, model, numberOfCars, price);
            CatalogOfCar.Add(AddedCar);
            Counter++;
            CallEvent(new CatalogEventArgs("New car. Id : " + Counter, 0, Counter), Added);
        }    
        
        public void Count(object CallingClass, string type)
        {
            if (!(CallingClass is CommandHandler))
            {
                throw new Exception();
            }

            var Count = CatalogOfCar.GroupBy(x => x.Brand).Count();
            CallEvent(new CatalogEventArgs($"{Count}", 0, Count), Counted);
        }
        
        public void Count(object CallingClass)
        {
            if (!(CallingClass is CommandHandler))
            {
                throw new Exception();
            }
            
            var Count = CatalogOfCar.Select(x => x.NumberOfCars).Sum(y => y);
            CallEvent(new CatalogEventArgs($"{Count}", 0, Count), Counted);
        }

        public void AveragePrice(object CallingClass)
        {
            if (!(CallingClass is CommandHandler))
            {
                throw new Exception();
            }

            var price = CatalogOfCar.Select(x => x.Price).Average(y => y);
            CallEvent(new CatalogEventArgs($"{price}", price, 1), Calculated);
        }
        
        public int AveragePrice(object CallingClass, string brand)
        {
            if (!(CallingClass is CommandHandler))
            {
                throw new Exception();
            }
            
            var price = CatalogOfCar.Where(x => x.Brand == brand).Select(x => x.Price).Average(y => y);
            CallEvent(new CatalogEventArgs($"{price}", price, 1), Calculated);
        }
    }
}