using System;

namespace Singleton
{
    public class LazySingleton
    {
        private static Lazy<LazySingleton> _instance = new Lazy<LazySingleton>(() => new LazySingleton());

        private LazySingleton() { }

        // The instance is created only when it is acccessed first time.
        public static LazySingleton Instance => _instance.Value;
    }
}