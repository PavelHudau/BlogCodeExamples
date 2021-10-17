using System;
namespace Factory.AbstractFactory
{
    public class TruckTester : CarTester
    {
        public override bool TestCar(Car car)
        {
            if (car is Truck truck)
            {
                return TestTruck(truck);
            }

            throw new NotSupportedException("Only Trucks are supported by the rester");
        }

        private bool TestTruck(Truck truck)
        {
            // Elaborate car testing logic.
            // ...
            return true;
        }
    }
}