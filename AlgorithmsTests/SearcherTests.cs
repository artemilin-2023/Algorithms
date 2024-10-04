using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tests
{
    [TestClass()]
    public class SearcherTests
    {
        [TestMethod()]
        public void LinearSearchTest_ElementExist()
        {
            var actual = new List<string>() { "A", "B", "C", "D" };
            Assert.AreEqual(2, actual.LinearSearch("C"));
        }

        [TestMethod()]
        public void LinearSearchTest_ElementDontExist()
        {
            var actual = new List<string>() { "A", "B", "C", "D" };
            Assert.AreEqual(-1, actual.LinearSearch("E"));
        }

        [TestMethod()]
        public void SentialSearchTest()
        {
            var actual = new List<int>() { 1, 2, 3, 4 };
            Assert.AreEqual(2, actual.SentialSearch(3));
        }

        [TestMethod()]
        public void SentialSearchTest_ElementDontExist()
        {
            var actual = new List<int>() { 1, 2, 3, 4 };
            Assert.AreEqual(-1, actual.SentialSearch(5));
        }

        [TestMethod()]
        public void BinarySearchTest_ElementExist()
        {

            var actual = new List<int>() { 1, 2, 3, 4 };
            Assert.AreEqual(2, Searcher.BinarySearch(actual, 3));
        }

        [TestMethod()]
        public void BinarySearchTest_ElementDontExist()
        {
            var actual = new List<int>() { 1, 2, 3, 4 };
            Assert.AreEqual(-1, Searcher.BinarySearch(actual, 5));
        }
    }
}