using System;
namespace Factory
{
    public class Truck: Car
    {
        public override bool RunTests()
        {
            // Truck specific tests;
            // ...
            var quality = new Random().Next(0, 100);
            return quality > 96;
        }
    }
}

