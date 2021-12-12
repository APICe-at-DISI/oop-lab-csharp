using System;

namespace Exceptions
{
    public class EmptyQueueException : QueueException
    {
        public EmptyQueueException()
        {
        }

        public EmptyQueueException(string message) : base(message)
        {
        }

        public EmptyQueueException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}