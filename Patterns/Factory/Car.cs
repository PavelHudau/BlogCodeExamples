using System;
namespace Factory
{
    public abstract class Car
    {
        public Car()
        {
            Vin = Guid.NewGuid().ToString();
        }

        public string Vin { get; private set; }

        public abstract bool RunTests();
    }
}