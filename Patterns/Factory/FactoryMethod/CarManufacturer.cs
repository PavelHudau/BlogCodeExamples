using System;
namespace Factory.FactoryMethod
{
    public class CarManufacturer
    {
        public Car MakeCar(Order order)
        {
            var carFactory = SelectCarFactory(order);
            var car = carFactory.CreateCar();
            if (!TestCar(car))
            {
                throw new Exception("Return car for fixing");
            }

            return car;
        }

        private bool TestCar(Car car)
        {
            // Elaborate car testing logic.
            // ...
            return true;
        }

        private CarFactory SelectCarFactory(Order order)
        {
            switch (order.Model)
            {
                case CarModel.Sedan:
                    return new SedanFactory();
                case CarModel.SUV:
                    return new SUVFactory();
                case CarModel.Truck:
                    return new TruckFactory();
                default:
                    throw new Exception($"Unable to select factory for {order.Model}");
            }
        }
    }
}