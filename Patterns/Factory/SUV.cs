using System;
namespace Factory
{
    public class SUV : Car
    {
        public override bool RunTests()
        {
            // SUV specific tests;
            // ...
            var quality = new Random().Next(0, 100);
            return quality > 93;
        }
    }
}

