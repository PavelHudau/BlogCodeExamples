using System;
namespace Factory.AbstractFactory
{
    public abstract class CarFactory
    {
        public abstract Car CreateCar();

        public abstract CarTester CreateTester();
    }
}