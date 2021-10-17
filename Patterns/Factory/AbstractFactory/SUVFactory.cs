using System;
namespace Factory.AbstractFactory
{
    public class SUVFactory : CarFactory
    {
        public override Car CreateCar()
        {
            return new SUV();
        }

        public override CarTester CreateTester()
        {
            return new SUVTester();
        }
    }
}