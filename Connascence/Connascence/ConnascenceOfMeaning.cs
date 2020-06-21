using System;

namespace ConnascenceOfMeaning
{
    public class Duck
    {
        private static readonly Random _rand;

        public Duck(string name)
        {
            Name = name;
            Location = _rand.Next(1, 4);
        }

        public string Name { get; }

        public int Location { get; }
    }

    public class Farm
    {
        public int FindDuck(Duck duck)
        {
            if (GoToBarn(duck) == "SUCCESS")
            {
                return 1;
            }

            if (GoToPond(duck) == "SUCCESS")
            {
                return 2;
            }

            if (GoToYard(duck) == "SUCCESS")
            {
                return 3;
            }

            return 0;
        }

        private string GoToBarn(Duck duck)
        {
            return duck.Location == 1 ? "SUCCESS" : "NO";
        }

        private string GoToPond(Duck duck)
        {
            return duck.Location == 2 ? "SUCCESS" : "NO";
        }

        private string GoToYard(Duck duck)
        {
            return duck.Location == 3 ? "SUCCESS" : "NO";
        }
    }
}