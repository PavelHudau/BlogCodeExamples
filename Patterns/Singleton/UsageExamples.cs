using System;
namespace Singleton
{
    public class UsageExamples
    {
        public void UsingReadonlySingleton()
        {
            var proxyUri = $"{MyAppConfiguration.Instance.ProxyHost}:{MyAppConfiguration.Instance.ProxyPort}";
            Console.Write($"Proxy address: {proxyUri}");
        }

        public void UsingPubSub()
        {
            // Subscribing to Loading event
            PubSubAsSingleton.Instance.LoadingEvent += (sender, args) =>
            {
                if (args.LoadedProgress >= 1)
                {
                    Console.WriteLine($"Loaded!");
                }
                else
                {
                    Console.WriteLine($"Loading... {args.LoadedProgress * 100}%");
                }
            };

            // Publishing Loading events
            for (var i = 0; i <= 100; i++)
            {
                PubSubAsSingleton.Instance.RaiseLoadingEvent(this, i / 100.0);
            }
        }
    }
}