using System;

namespace Singleton
{
    public class MyAppConfiguration
    {
        /// <summary>
        /// Instantiates single instance of MyAppConfiguration.
        /// </summary>
        private static readonly MyAppConfiguration _instance = new MyAppConfiguration
        {
            ProxyHost = System.Environment.GetEnvironmentVariable("PROXY"),
            ProxyPort = int.Parse(System.Environment.GetEnvironmentVariable("PROXY"))
        };

        /// <summary>
        /// Private constructor.
        /// Making constructor private blocks external code from creating
        /// new instances of MyAppConfiguration.
        /// </summary>
        private MyAppConfiguration() { }

        /// <summary>
        /// Returns single instance of MyAppConfiguration
        /// </summary>
        public static MyAppConfiguration Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Returns proxy host.
        /// </summary>
        public string ProxyHost { get; private set; }

        /// <summary>
        /// Returns proxy port.
        /// </summary>
        public int ProxyPort { get; private set; }
    }
}