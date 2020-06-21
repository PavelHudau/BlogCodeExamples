using System;

namespace ConnascenceOfTYpe
{
    public class Duck
    {
        private readonly int duckIndex;

        public Duck(int duckIndex)
        {
            this.duckIndex = duckIndex;
        }

        public string Quack()
        {
            return $"Quack : {duckIndex}";
        }
    }

    public class Farm
    {
        public string WhatDuckSays(Duck duck)
        {
            return duck.Quack();
        }

        public void AnimalsTalk()
        {
            // OK
            var duck1 = new Duck(1);

            // COMPILE ERROR
            // Duck expects int, but string was passed
            var duck2 = new Duck("2");

            // OK
            var whatDuck1Said = WhatDuckSays(duck1);

            // COMPILE ERROR
            // WhatDuckSays expects a Duck as argument, but string was passes.
            var whatDuck2Said = WhatDuckSays("A Duck");
        }
    }
}