using System;

namespace Connascence
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
        public void AnimalsTalk()
        {
            // 1. If we rename Duck class we will have to change
            //    the class name to make code compiled.
            // 2. We may also need to change duck1 and duck2 names
            //    to keep it consistent with the Duck class name.
            var duck1 = new Duck(1);
            var duck2 = new Duck(2);

            // 3. If we change Quack methind name,
            //    this line needs to chage as well.
            var whatWasSaid = duck1.Quack() + duck2.Quack();

            Console.WriteLine(whatWasSaid);
        }
    }
}
