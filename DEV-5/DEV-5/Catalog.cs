using System;
using System.Collections.Generic;

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
        
        public void AddCar(string brand, string model, int numberOfCars, int price)
        {
            if ((Capacity < Counter + 1) && (Capacity != -1))
            {
                throw new Exception();
            }
            
            var AddedCar = new Car(this, brand, model, numberOfCars, price);
            CatalogOfCar.Add(AddedCar);
            Counter++;
            CallEvent(new CatalogEventArgs("New car. Id : " + Counter, Counter), Added);
        }
 /*       
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
        */
    }
}