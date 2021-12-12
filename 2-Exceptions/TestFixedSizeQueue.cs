using NUnit.Framework;

namespace Exceptions
{
    public class TestFixedSizeQueue
    {
        private const uint DefaultCapacity = 5;

        [Test]
        public void QueueIsInitiallyEmpty()
        {
            IFixedSizeQueue queue = new FixedSizeQueue(DefaultCapacity);
            Assert.AreEqual(DefaultCapacity, queue.Capacity);
            Assert.AreEqual(0u, queue.Count);
        }
        
        [Test]
        public void CannotGetItemsFromEmptyQueue()
        {
            IFixedSizeQueue queue = new FixedSizeQueue(DefaultCapacity);
            Assert.AreEqual(0u, queue.Count);
            
            try
            {
                queue.GetFirst();
                Assert.Fail();
            }
            catch (EmptyQueueException)
            {
                Assert.Pass();
            }
        }
        
        [Test]
        public void QueueCanBeFilledUpToItsCapacity()
        {
            IFixedSizeQueue queue = new FixedSizeQueue(DefaultCapacity);
            
            for (int i = 0; i < queue.Capacity; i++)
            {
                queue.AddLast(i);
                Assert.AreEqual(i + 1, queue.Count);
            }

            try
            {
                queue.AddLast("one more item");
                Assert.Fail();
            }
            catch (FullQueueException)
            {
                Assert.Pass();
            }
        }
        
        [Test]
        public void ItemsAreRetrievedFromQueueInTheSameOrderTheyHaveBeenInserted()
        {
            IFixedSizeQueue queue = new FixedSizeQueue(DefaultCapacity);
            
            for (int round = 0; round < 3; round++)
            {
                for (int i = 0; i < queue.Capacity; i++)
                {
                    queue.AddLast(i);
                    Assert.AreEqual(i + 1, queue.Count);
                }
                for (int i = 0; i < queue.Capacity; i++)
                {
                    Assert.AreEqual(i, queue.GetFirst());
                    Assert.AreEqual(queue.Capacity - i - 1, queue.Count);
                }
            }
        }
    }
}