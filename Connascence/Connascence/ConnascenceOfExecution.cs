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
}