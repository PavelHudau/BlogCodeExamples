using System;
namespace Factory.FactoryMethod
{
    public class SedanFactory : CarFactory
    {
        public override Car CreateCar()
        {
            return new Sedan();
        }
    }
}