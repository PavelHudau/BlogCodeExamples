namespace ConnascenceOfPosition
{
    public class UserFactory
    {
        public string[] CreateUser(
            string firstName,
            string lastName,
            string phoneNumber)
        {
            // User is represented as an array where
            // each element position has meening.
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

    public class UserFactoryFixed
    {
        public User CreateUser(
            string firstName,
            string lastName,
            string phoneNumber)
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