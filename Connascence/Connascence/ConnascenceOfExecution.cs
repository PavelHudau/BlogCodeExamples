using System;

namespace ConnascenceOfExecution
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public void Save()
        {
            // Save to storage here.
        }
    }

    public class UserRepository
    {
        public void SaveUser(string firstName, string lastName, string phoneNumber)
        {
            var user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Save();
            user.PhoneNumber = "111-111-11111";
        }
    }

    public class Cappuccino
    {
        public void Grind() { }
        public void PressCoffee() { }
        public void AddWater() { }
        public void AddMilk() { }
        public void TurnOnMachine() { }
        public void Wait() { }
        public void Serve() { }
    }

    public class Americano
    {
        public void Grind() { }
        public void AddCoffee() { }
        public void AddWater() { }
        public void TurnOnMachine() { }
        public void Wait() { }
        public void Serve() { }
    }

    public class Barista
    {
        public void BrewAmericano(Americano coffee)
        {
            // Sequence of steps is important and
            // is duplicated in every coffee class. 
            coffee.Grind();
            coffee.AddCoffee();
            coffee.AddWater();
            coffee.TurnOnMachine();
            coffee.Wait();
            coffee.Serve();
        }

        public void Brew(Cappuccino coffee)
        {
            coffee.Grind();
            coffee.PressCoffee();
            coffee.AddWater();
            coffee.AddMilk();
            coffee.TurnOnMachine();
            coffee.Wait();
            coffee.Serve();
        }
    }
}

namespace ConnascenceOfExecutionFixed
{
    public interface ICoffee
    {
        void Prepare();
        void AddExtras();
    }

    public class Cappuccino : ICoffee
    {
        public void Prepare()
        {
            PressCoffee();
            AddWater();
            AddMilk();
        }

        public void AddExtras()
        {
            MakeCinnamonPrint();
        }

        private void PressCoffee() { }
        private void AddWater() { }
        private void AddMilk() { }
        private void MakeCinnamonPrint() { }
    }

    public class Americano : ICoffee
    {
        public void Prepare()
        {
            AddCoffee();
            AddWater();
        }

        public void AddExtras() { }

        private void AddCoffee() { }
        private void AddWater() { }
    }

    public class Barista
    {
        // Sequence of basic steps is implemented as template method.
        public void Brew(ICoffee coffee)
        {
            Grind();
            coffee.Prepare();
            TurnOnMachine();
            Wait();
            coffee.AddExtras();
            Serve();
        }

        private void Grind() { }
        private void TurnOnMachine() { }
        private void Wait() { }
        private void Serve() { }
    }
}