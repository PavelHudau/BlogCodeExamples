using System;
namespace Factory.AbstractFactory
{
    public class SedanTester : CarTester
    {
        public override bool TestCar(Car car)
        {
            if (car is Sedan sedan)
            {
                return TestSedan(sedan);
            }

            throw new NotSupportedException("Only sedans are supported by the rester");
        }

        private bool TestSedan(Sedan sedan)
        {
            // Elaborate car testing logic.
            // ...
            return true;
        }
    }
}