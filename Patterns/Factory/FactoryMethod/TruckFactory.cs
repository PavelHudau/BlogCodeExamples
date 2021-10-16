using System;
namespace Factory.FactoryMethod
{
    public class TruckFactory : CarFactory
    {
        public override Car CreateCar()
        {
            return new Truck();
        }
    }
}