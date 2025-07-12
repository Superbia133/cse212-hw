using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    /// <summary>
    /// Test: Dequeue should return the item with the highest priority.
    /// Items added: "A" (priority 1), "B" (priority 5), "C" (priority 3)
    /// Expected: "B" dequeued first
    /// </summary>
    [TestMethod]
    public void TestPriorityQueue_1()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 1);
        queue.Enqueue("B", 5);
        queue.Enqueue("C", 3);

        var result = queue.Dequeue();
        Assert.AreEqual("B", result);
    }

    /// <summary>
    /// Test: Dequeue from multiple items with same highest priority.
    /// Items added: "X" (priority 4), "Y" (priority 4), "Z" (priority 2)
    /// Expected: "X" dequeued first (FIFO for tie)
    /// </summary>
    [TestMethod]
    public void TestPriorityQueue_2()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("X", 4);
        queue.Enqueue("Y", 4);
        queue.Enqueue("Z", 2);

        var result = queue.Dequeue();
        Assert.AreEqual("X", result);
    }
}
