using System;

namespace ConnascenceOfPosition
{
    public class Farm
    {
        public string[] GetUser(string firstName, string lastName, string phoneNumber)
        {
            return new string[] {
                firstName,
                lastName,
                phoneNumber
            };
        }
    }

    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class Farm2
    {
        public User GetUser(string firstName, string lastName, string phoneNumber)
        {
            return new User
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber
            };
        }
    }
}