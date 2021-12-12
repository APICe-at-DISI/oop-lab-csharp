using System;

namespace Exceptions
{
    public abstract class QueueException : InvalidOperationException
    {
        protected QueueException()
        {
        }

        protected QueueException(string message) : base(message)
        {
        }

        protected QueueException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}