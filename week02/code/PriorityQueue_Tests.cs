using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities
    // Scenario: A(1), B(5), C(3)
    // Expected Result: B should be removed first because it has highest priority
    // Defect(s) Found: No defects found. Highest priority is removed correctly.
    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("B", result);
    }


    [TestMethod]
    // Scenario: Add three items with the same priority
    // Scenario: A(3), B(3), C(3)
    // Expected Result: A should be removed first (FIFO order)
    // Defect(s) Found: No defects found. FIFO order is maintained when priorities are equal.
    public void TestPriorityQueue_FIFOWhenSamePriority()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Remove multiple items and verify order of priority
    // Scenario: A(1), B(5), C(3)
    // Expected Result: B, C, A
    // Defect(s) Found: No defects found. Priority order works correctly.
    public void TestPriorityQueue_MultipleRemovals()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: No defects found. Correct exception is thrown.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}