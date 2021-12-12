using System;

namespace Exceptions
{
    public class FullQueueException : QueueException
    {
        public FullQueueException()
        {
        }

        public FullQueueException(string message) : base(message)
        {
        }

        public FullQueueException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}