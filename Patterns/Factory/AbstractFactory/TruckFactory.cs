using System;
namespace Factory.AbstractFactory
{
    public class TruckFactory : CarFactory
    {
        public override Car CreateCar()
        {
            return new Truck();
        }

        public override CarTester CreateTester()
        {
            return new TruckTester();
        }
    }
}