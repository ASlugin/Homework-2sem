namespace Queue.Tests;

using NUnit.Framework;
using Queue;

public class Tests
{
    [Test]
    public void NewQueueShallBeEmpty()
    {
        PriorityQueue<char> queue = new();
        Assert.IsTrue(queue.Empty);
    }

    [Test]
    public void QueueWithElementsShallNotBeEmpty()
    {
        PriorityQueue<string> queue = new();
        queue.Enqueue("Ololo", 1);
        Assert.IsFalse(queue.Empty);
    }

    [Test]
    public void QueueAfterDenqueueAllElementsShallBeEmpty()
    {
        PriorityQueue<double> queue = new();
        queue.Enqueue(1.234, 1);
        queue.Enqueue(2.3455, 10);
        queue.Dequeue();
        queue.Dequeue();
        Assert.IsTrue(queue.Empty);
    }

    [Test]
    public void FirstInFirstOutForElementsWithSamePriorities()
    {
        PriorityQueue<int> queue = new();
        queue.Enqueue(1, 10);
        queue.Enqueue(2, 10);
        queue.Enqueue(3, 10);
        for (int i = 1; i <= 3; ++i)
        {
            Assert.AreEqual(i, queue.Dequeue());
        }

        PriorityQueue<string> queueString = new();
        queueString.Enqueue("abcd", 10);
        queueString.Enqueue("qwerty", 10);
        queueString.Enqueue("ololo", 10);
        Assert.AreEqual(0, string.Compare("abcd", queueString.Dequeue()));
        Assert.AreEqual(0, string.Compare("qwerty", queueString.Dequeue()));
        Assert.AreEqual(0, string.Compare("ololo", queueString.Dequeue()));
    }

    [Test]
    public void ElementsShallBeReturnedByPriorities()
    {
        PriorityQueue<char> queue = new();
        queue.Enqueue('3', 5);
        queue.Enqueue('1', 10);
        queue.Enqueue('2', 10);
        queue.Enqueue('4', 1);
        for (int i = 1; i <= 4; ++i)
        {
            Assert.AreEqual((char)(i + (int)'0'), queue.Dequeue());
        }
    }

    [Test]
    public void DequeueFromEmptyQueueShallThrowException()
    {
        PriorityQueue<byte> queue = new();
        Assert.Throws<DequeueFromEmptyQueueException>(() => queue.Dequeue());

        queue.Enqueue(1, 2);
        queue.Dequeue();
        Assert.Throws<DequeueFromEmptyQueueException>(() => queue.Dequeue());
    }
}
