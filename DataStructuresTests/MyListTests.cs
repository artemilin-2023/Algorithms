using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests
{
    [TestClass()]
    public class MyListTests
    {

        private static MyList<int> list;

        [TestInitialize]
        public void Initialise()
        {
            list = new MyList<int>();
        }

        [TestMethod()]
        public void AddTest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.AreEqual(3, list.Count);
        }

        [TestMethod()]
        public void CopyTo_CopyAll()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            var actual = new int[3];
            list.CopyTo(actual, 0);

            var expected = new[] { 1, 2, 3 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CopyTo_CopyPart_ArrayIsSmaller()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            var actual = new int[2];
            Assert.ThrowsException<ArgumentException>(() =>  list.CopyTo(actual));
        }

        [TestMethod()]
        public void CopyTo_CopyPart_ArrayIsBigger()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            var actual = new int[4];
            list.CopyTo(actual, 1);

            var expected = new[] { 0, 1, 2, 3 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CopyTo_NullArray()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            int[] actual = null;

            Assert.ThrowsException<ArgumentNullException>(() => list.CopyTo(actual));
        }

        [TestMethod()]
        public void ClearTest()
        {
            list.Add(0);
            Assert.AreEqual(1, list.Count);

            list.Clear();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod()]
        public void ContainsTest_FirstElement()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            Assert.IsTrue(list.Contains(1));
        }

        [TestMethod()]
        public void ContainsTest_MiddleElement()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            Assert.IsTrue(list.Contains(3));
        }

        [TestMethod()]
        public void ContainsTest_LastElement()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            Assert.IsTrue(list.Contains(4));
        }

        [TestMethod()]
        public void ContainsTest_ElementNotContained()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            Assert.IsTrue(!list.Contains(5));
        }

        [TestMethod()]
        public void IndexOfTest_ElementExist()
        {
            list.Add(1);
            list.Add(2);

            Assert.AreEqual(1, list.IndexOf(2));
        }

        [TestMethod()]
        public void IndexOfTest_ElementDontExist()
        {
            list.Add(1);
            list.Add(2);

            Assert.AreEqual(-1, list.IndexOf(3));
        }

        [TestMethod()]
        public void GetSetTest()
        {
            list.Add(1);
            Assert.AreEqual(1, list[0]);

            list[0] = -1;
            Assert.AreEqual(-1, list[0]);
        }

        [TestMethod()]
        public void GetEnumeratorTest_NormalData()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            var actual = new List<int>();
            foreach (var item in list)
                actual.Add(item);
            CollectionAssert.AreEqual(new List<int>() { 1, 2, 3 }, actual);
        }

        [TestMethod()]
        public void GetEnumeratorTest_EmtyList()
        {
            var actual = new List<int>();
            foreach (var item in list)
                actual.Add(item);
            CollectionAssert.AreEqual(new List<int>(), actual);
        }

        [TestMethod()]
        public void InsertTest_InsertIntoMiddle()
        {
            list.Add(0);
            list.Add(2);

            list.Insert(1, 1);

            var actual = new int[3];
            list.CopyTo(actual);
            CollectionAssert.AreEqual(new[] { 0, 1, 2 }, actual);
        }

        [TestMethod()]
        public void InsertTest_InsertIntoHead()
        {
            list.Add(1);
            list.Add(2);

            list.Insert(0, 0);

            var actual = new int[3];
            list.CopyTo(actual);
            CollectionAssert.AreEqual(new[] { 0, 1, 2 }, actual);
        }

        [TestMethod()]
        public void InsertTest_WrongIndex()
        {
            list.Add(1);
            list.Add(2);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.Insert(2, 3));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            list.Add(0);
            list.Add(1);
            list.Add(2);
            Assert.AreEqual(3, list.Count);

            list.Remove(1);
            Assert.AreEqual(2, list.Count);

            list.Remove(2);
            Assert.AreEqual(1, list.Count);

            list.Remove(0);
            Assert.AreEqual(0, list.Count);

            CollectionAssert.AreEqual(new int[0], list.ToArray());
        }

        [TestMethod()]
        public void RemoveAtTest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.RemoveAt(1);
            list.RemoveAt(list.Count - 1);
            list.RemoveAt(0);

            Assert.AreEqual(0, list.Count);
            CollectionAssert.AreEqual(new int[0], list.ToArray());
        }
    }
}