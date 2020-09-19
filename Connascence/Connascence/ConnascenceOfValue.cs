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
        public int SaveOrUpdateUser(User user)
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
        // 1. Give name to default value of User.Id
        private const int NewUserId = -1;
        public User()
        {
            Id = NewUserId;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        // 2. Add property to check if user is new
        public bool IsNew => Id == NewUserId;
    }

    public abstract class UserRepository
    {
        public int SaveOrUpdateUser(User user)
        {
            // 3. Use User.IsNew
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
        ...
    }

    public class UserServiceProxy
    {
        public string SaveUser(User user)
        {
            // Returns result of the operation as string.
        }
    }

    public class UserUiController
    {
        public void SaveUserData(User user)
        {
            var userService = new UserServiceProxy();
            var response = userService.SaveUser(user);
            if (!response.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
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

namespace ConnascenceOfValueErrorHandlingExampleFixed
{
    public class User
    {
        ...
    }

    // 1. Define error codes explicitly
    public enum UserServiceResponseCode
    {
        Success = 0,
        DatabaseError = 2
    }

    public class UserServiceResponse
    {
        public const int DatabaseError = 2;
        public UserServiceResponseCode ErrorCode { get; set; }
        public int ErrorMessage { get; set; }
        public bool IsSuccess => ErrorCode == UserServiceResponseCode.Success;
    }

    public class UserServiceProxy
    {
        public UserServiceResponse SaveUser(User user)
        {
            ...
        }
    }

    public class UserUiController
    {
        public void SaveUserData(User user)
        {
            var userService = new UserServiceProxy();
            var response = userService.SaveUser(user);

            // 2. Now check for success result is easy
            if (response.IsSuccess)
            {
                return;
            }

            // 3. Check for the type of error is easy too.
            if (response.ErrorCode == UserServiceResponseCode.DatabaseError)
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