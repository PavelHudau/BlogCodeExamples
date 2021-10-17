using System;
namespace Factory.FactoryMethod
{
    public class SUVFactory : CarFactory
    {
        public override Car CreateCar()
        {
            return new SUV();
        }
    }
}