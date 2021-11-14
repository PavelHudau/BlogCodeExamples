using System;

namespace Singleton
{
    public class GreedySingleton
    {
        // New instance is created when CLR loads the class. Thread safety is guaranteed.
        private static GreedySingleton _instance = new GreedySingleton();

        private GreedySingleton() { }

        // The property just returns created instance.
        public static GreedySingleton Instance => _instance;
    }
}