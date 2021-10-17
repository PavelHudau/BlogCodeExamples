using System;
namespace Factory.AbstractFactory
{
    public class SedanFactory : CarFactory
    {
        public override Car CreateCar()
        {
            return new Sedan();
        }

        public override CarTester CreateTester()
        {
            return new SedanTester();
        }
    }
}