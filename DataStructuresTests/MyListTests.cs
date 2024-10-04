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
        private static MyList<int> list = new MyList<int>();

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
        public void CopyTo_CopyPartIfDimensionOfTheArrayIsSmaller()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            var actual = new int[2];
            list.CopyTo(actual, 1);

            var expected = new[] { 2, 3 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ClearTest()
        {
            list.Add(0);
            Assert.AreEqual(1, list.Count);

            list.Clear();
            Assert.AreEqual(0, list.Count);
        }
    }
}