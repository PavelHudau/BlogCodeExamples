using System;
namespace Factory.AbstractFactory
{
    public class SUVTester : CarTester
    {
        public override bool TestCar(Car car)
        {
            if (car is SUV suv)
            {
                return TestSUV(suv);
            }

            throw new NotSupportedException("Only SUVs are supported by the rester");
        }

        private bool TestSUV(SUV suv)
        {
            // Elaborate car testing logic.
            // ...
            return true;
        }
    }
}