namespace Singleton
{
    public class NotThreadSafeSingleton
    {
        private static NotThreadSafeSingleton _instance;

        private NotThreadSafeSingleton() { }

        public static NotThreadSafeSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Thread 1 switches here before assigning _instance.
                    // Thread 2 runs until this point and creates 2-nd instance.
                    _instance = new NotThreadSafeSingleton();
                }

                return _instance;
            }
        }
    }
}