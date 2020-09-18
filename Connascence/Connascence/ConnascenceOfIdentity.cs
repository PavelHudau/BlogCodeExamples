using System;
using System.Collections.Generic;

namespace ConnascenceOfIdentityBad
{
    public class Publisher
    {
        public Queue<string> Queue { get; private set; } = new Queue<string>();

        public void Publish(string message)
        {
            Queue.Enqueue(message);
        }
    }

    public class Subscriber
    {
        public void Consume(Publisher publisher)
        {
            Console.WriteLine(publisher.Queue.Dequeue());
        }
    }
}


namespace ConnascenceOfIdentityFixed
{
    public class Publisher
    {
        private readonly Queue<string> _queue;

        public Publisher(Queue<string> queue)
        {
            _queue = queue;
        }

        public void Publish(string message)
        {
            _queue.Enqueue(message);
        }
    }

    public class Subscriber
    {
        private readonly Queue<string> _queue;

        public Subscriber(Queue<string> queue)
        {
            _queue = queue;
        }

        public void Consume()
        {
            Console.WriteLine(_queue.Dequeue());
        }
    }
}