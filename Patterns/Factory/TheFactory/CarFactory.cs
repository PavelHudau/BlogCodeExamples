using System;
namespace Factory.TheFactory
{
    public class CarFactory
    {
        public Sedan CreateSedan()
        {
            var sedan = new Sedan();
            // Some complicated logic;
            // ...

            return sedan;
        }

        public SUV CreateSUV()
        {
            var suv = new SUV();
            // Some complicated logic;
            // ...

            return suv;
        }

        public Truck CreateTruck()
        {
            var truck = new Truck();
            // Some complicated logic;
            // ...

            return truck;
        }
    }
}