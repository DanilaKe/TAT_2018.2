using System;

namespace DEV_8
{
    /// <summary>
    /// Class Car
    /// Information about cars of the same brand and their number.
    /// </summary>
    public sealed class Car : Machine
    {
        public Car(string brand, string model, int numberOfCars, decimal price) : base(brand, model, numberOfCars, price) { }
    }
}