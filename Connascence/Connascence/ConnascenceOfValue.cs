using System;

namespace ConnascenceOfValue
{
    public class User
    {
        public User()
        {
            // If user is new, Id property has
            // vlaue -1
            Id = -1;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }

    public abstract class UserRepository
    {
        public int SaveUser(User user)
        {
            // We make an assumption if user.Id property is -1
            // then user is new and needs to be inserted.
            // Othereise we update existing user.
            if (user.Id == -1)
            {
                return InserttUser(user);
            }
            else
            {
                return UpdateUser(user);
            }
        }

        public abstract int InserttUser(User user);
        public abstract int UpdateUser(User user);
    }
}

namespace ConnascenceOfValueFixed
{
    public class User
    {
        private const int NewUserId = -1;
        public User()
        {
            // If user is new, Id property has
            // value -1
            Id = NewUserId;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsNew => Id == NewUserId;
    }

    public abstract class UserRepository
    {
        public int SaveUser(User user)
        {
            // This code now has no dependency on initial id
            // of new user. It only needs to check IsNew property.
            if (user.IsNew)
            {
                return InserttUser(user);
            }
            else
            {
                return UpdateUser(user);
            }
        }

        public abstract int InserttUser(User user);
        public abstract int UpdateUser(User user);
    }
}


namespace ConnascenceOfValueErrorHandlingExample
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class UserServiceProxy
    {
        public string SaveUser(User user)
        {
            // Returns result of an operation as string.
        }
    }

    public class UserUiController
    {
        public SaveUserData(User user)
        {
            var userService = new UserServiceProxy();
            var response = userService.SaveUser(user);
            if (response.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                if (response.Contains("database", StringComparison.OrdinalIgnoreCase))
                {
                    throw new DatabaseException("Can't save user");
                }
                else
                {
                    throw new ApplicationException("Fialed to save user, unknown reason");
                }
            }
        }
    }
}