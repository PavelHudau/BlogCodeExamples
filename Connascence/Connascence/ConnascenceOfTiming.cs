using System.Threading.Tasks;

namespace ConnascenceOfTiming
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }

    public abstract class UserRepository
    {
        public User SaveUser(string firstName, string lastName, string phoneNumber)
        {
            var user = new User();
            var saveUserTask = SaveUserAsync(user);
            // We need to await saveUserTask completeion.
            // If we do not, then saveUserTask may not be completed
            // before we attempt to load user. This may cause
            // undefined behavior or exception.
            var savedUserId = saveUserTask.Result;
            // User must be saved before we attempt to load.
            var loadedUserTask = LoadUserAsync(savedUserId);
            return loadedUserTask.Result;
        }

        public abstract Task<int> SaveUserAsync(User user);

        public abstract Task<User> LoadUserAsync(int id);
    }
}