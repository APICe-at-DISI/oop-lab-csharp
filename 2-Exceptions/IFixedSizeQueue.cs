namespace Exceptions
{
    public interface IFixedSizeQueue
    {
        /// <summary>
        /// The maximum amount of items in the queue
        /// </summary>
        uint Capacity { get; }
        
        /// <summary>
        /// The current amount of items in the queue
        /// </summary>
        uint Count { get; }

        /// <summary>
        /// Retrieves (and removes) the first item in the queue, if any
        /// </summary>
        /// <exception cref="EmptyQueueException">if the queue is empty</exception>
        object GetFirst();

        /// <summary>
        /// Appends an item at the end of the queue, if possible
        /// </summary>
        /// <param name="item">the item to be appended</param>
        /// <exception cref="FullQueueException">if the queue is full</exception>
        void AddLast(object item);
    }
}