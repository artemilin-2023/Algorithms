using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests
{
    [TestClass()]
    public class MyQueueTests
    {
        private static MyQueue<string> queue = new();

        [TestInitialize]
        public void ClassInitialize()
        {
            queue = new MyQueue<string>();
        }

        [TestMethod()]
        public void EnqueueTest()
        {
            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");

            Assert.AreEqual(3, queue.Count);
        }

        [TestMethod()]
        public void DequeueTest()
        {
            string result;

            queue.Enqueue("A");
            queue.Enqueue("AA");
            queue.Enqueue("AAA");

            result = queue.Dequeue();
            Assert.AreEqual("A", result);
            result = queue.Dequeue();
            Assert.AreEqual("AA", result);
            result = queue.Dequeue();
            Assert.AreEqual("AAA", result);

        }

        [TestMethod()]
        public void PeekTest()
        {
            queue.Enqueue("A");
            queue.Enqueue("AA");
            queue.Enqueue("AAA");

            Assert.AreEqual("A", queue.Peek());
            Assert.AreEqual("A", queue.Peek());
        }

        [TestMethod()]
        public void ContainsTest_True()
        {
            queue.Enqueue("A");
            queue.Enqueue("AA");
            queue.Enqueue("AAA");

            Assert.IsTrue(queue.Contains("AA"));
            Assert.IsTrue(queue.Contains("AAA"));
            Assert.IsTrue(queue.Contains("A"));
        }

        [TestMethod()]
        public void ContainsTest_False()
        {
            queue.Enqueue("A");
            queue.Enqueue("AA");
            queue.Enqueue("AAA");

            Assert.IsFalse(queue.Contains("a"));
        }

        [TestMethod()]
        public void ClearTest()
        {
            queue.Enqueue("hello");
            queue.Enqueue(",");
            queue.Enqueue("world");
            queue.Enqueue("!");

            Assert.AreEqual(4, queue.Count);
            queue.Clear();

            Assert.AreEqual(0, queue.Count);
            CollectionAssert.AreEqual(new string[0], queue.ToArray());
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            queue.Enqueue("hello");
            queue.Enqueue(",");
            queue.Enqueue(" ");
            queue.Enqueue("world");
            queue.Enqueue("!");

            var result = "";
            foreach (var item in queue)
                result += item;

            Assert.AreEqual("hello, world!", result);
        }

        [TestMethod()]
        public void CopyToTest()
        {
            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");

            var actural = new string[3];
            queue.CopyTo(actural);
            CollectionAssert.AreEqual(new[] {"A", "B", "C"}, actural);
        }
    }
}