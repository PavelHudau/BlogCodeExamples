using System;
namespace Factory
{
    public class Sedan : Car
    {
        public override bool RunTests()
        {
            // Sedan specific tests;
            // ...
            var quality = new Random().Next(0, 100);
            return quality > 95;
        }
    }
}

