namespace DEV_8
{
    /// <summary>
    /// Class Truck
    /// Information about truck of the same brand and their number.
    /// </summary>
    public sealed class Truck : Machine
    {
        public Truck(string brand, string model, int numberOfCars, decimal price) : base(brand, model, numberOfCars, price) { }
    }
}