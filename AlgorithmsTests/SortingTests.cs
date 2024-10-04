using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Algorithms.Tests
{
    [TestClass()]
    public class SortingTests
    {
        [TestMethod()]
        public void MergeSortTest_SmallArray()
        {
            var actual = new[] { 1, 3, 2, 5, 4 };
            actual.MergeSort();
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, actual);
        }

        [TestMethod()]
        public void MergeSortTest_EmptyArray()
        {
            var actual = new int[0];
            actual.MergeSort();
            CollectionAssert.AreEqual(new int[0], actual);
        }

        [TestMethod()]
        public void MergeSortTest_LargeArray()
        {
            const int elementsAmount = 100000000;
            var actual = new List<int>();
            var expected = new List<int>();
            var random = new Random();
            for (int i = 0; i < elementsAmount; i++)
            {
                var item = random.Next(i);
                actual.Add(item);
                expected.Add(item);
            }

            Sorting.MergeSort(actual);
            expected.Sort();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuickSortTest_SmallArray()
        {
            var result = Sorting.QuickSort(new List<int> { 3, 1, 2, 5 });
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 5}, (ICollection)result);
        }

        [TestMethod()]
        public void QuickSortTest_EmptyArray()
        {
            var result = Sorting.QuickSort(new List<int>());
            CollectionAssert.AreEqual(new List<int>(), (ICollection)result);
        }

        [TestMethod()]
        public void QuickSortTest_LargeArray()
        {
            const int elementsAmount = 100000000;
            var actual = new List<int>();
            var expected = new List<int>();
            var random = new Random();
            for (int i = 0; i < elementsAmount; i++)
            {
                var item = random.Next(i);
                actual.Add(item);
                expected.Add(item);
            }

            Sorting.QuickSort(actual);
            expected.Sort();
            
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BubbleSortTest_SmallArray()
        {
            var actual = new[] { 1.1f, 3.2f, 2.0f, 5.2f, 4f, 5.1f };
            actual.MergeSort();
            CollectionAssert.AreEqual(new[] { 1.1f, 2.0f, 3.2f, 4f, 5.1f, 5.2f }, actual);
        }
    }
}