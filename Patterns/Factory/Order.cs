using System;
namespace Factory
{
    public class Order
    {
        public Order(CarModel model)
        {
            Model = model;
        }

        public CarModel Model { get; private set; }
    }
}