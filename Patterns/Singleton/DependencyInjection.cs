using Microsoft.Extensions.DependencyInjection;

namespace Singleton
{
    public class Program
    {
        public static void Main()
        {
            // Configure DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<SingletonToBeConfiguredInDi>()
                .BuildServiceProvider();

            // Use DI to retrieve the singleton instance.
            var singletonInstance = serviceProvider.GetService<SingletonToBeConfiguredInDi>();
            var sameSingletonInstance = serviceProvider.GetService<SingletonToBeConfiguredInDi>();
        }
    }

    public class SingletonToBeConfiguredInDi
    {
        // There is no need to write any singleton plumbing code.
    }
}