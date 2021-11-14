using System;

namespace Singleton
{
    /// <summary>
    /// Singleton that handles Publishers and Subscriber
    /// </summary>
    public class PubSubAsSingleton
    {
        private static readonly PubSubAsSingleton _instance = new PubSubAsSingleton();

        private PubSubAsSingleton() { }

        public static PubSubAsSingleton Instance => _instance;

        /// <summary>
        /// Sunscribe if you would like to be notified about loading progress
        /// </summary>
        public event EventHandler<LoadingEventArgs> LoadingEvent;

        /// <summary>
        /// Use this mething if you would like to publish Loading events.
        /// </summary>
        /// <param name="sender">Identify who is the sender.</param>
        /// <param name="loadedProgress">Provide loading progress to sunscribers.</param>
        public void RaiseLoadingEvent(object sender, double loadedProgress)
        {
            var loadingEvent = LoadingEvent;
            loadingEvent?.Invoke(sender, new LoadingEventArgs(loadedProgress));
        }
    }

    /// <summary>
    /// Class that implements LoadingEvent arguments.
    /// </summary>
    public class LoadingEventArgs
    {
        public LoadingEventArgs(double loadedProgress)
        {
            LoadedProgress = loadedProgress;
        }

        public double LoadedProgress { get; private set; }
    }
}