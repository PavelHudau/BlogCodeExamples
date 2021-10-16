using System;
namespace Factory.PrivateFactory
{
    public class CarManufacturer
    {
        public Car MakeCar(Order order)
        {
            var car = CreateOrderedCar(order);
            // Some complicated logic that configured the car.
            // ...

            return car;
        }

        // Private Factory
        private Car CreateOrderedCar(Order order)
        {
            switch (order.Model)
            {
                case CarModel.Sedan:
                    return new Sedan();
                case CarModel.SUV:
                    return new SUV();
                case CarModel.Truck:
                    return new Truck();
                default:
                    throw new Exception($"Unable to make {order.Model}");
            }
        }
    }
}