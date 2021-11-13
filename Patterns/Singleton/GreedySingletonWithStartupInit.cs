using System;

namespace Singleton
{
    public class GreedySingletonWithStartupInit
    {
        private static object lockObj = new object();
        private static GreedySingletonWithStartupInit _instance;

        private GreedySingletonWithStartupInit() { }

        /// <summary>
        /// The property just returns created and initialized
        /// GreedySingletonWithStartupInit instance.
        /// If the instance is not initialized InvalidOperationException is thrown.
        /// </summary>
        public static GreedySingletonWithStartupInit Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException(
                        $"{nameof(GreedySingletonWithStartupInit)} is not initialized ");
                }

                return _instance;
            }
        }

        /// <summary>
        /// Initializes GreedySingletonWithStartupInit one time.
        /// Must be invoked on application startup.
        /// </summary>
        public static void InitializeOnAppStartup()
        {
            lock (lockObj)
            {
                if (_instance == null)
                {
                    _instance = new GreedySingletonWithStartupInit();
                    _instance.Initialize();
                }
                else
                {
                    throw new InvalidOperationException(
                        $"{nameof(GreedySingletonWithStartupInit)} already initialized");
                }
            }
        }

        private void Initialize()
        {
            // Heavy initialization logic goes here.
        }
    }
}