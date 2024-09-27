using NUnit.Framework;
using System.Collections.Generic;
using TurboCollections;

namespace TurboCollections.Test
{
    public class SelectionSortTests
    {
        [Test]
        public void SelectionSort_SortsUnsortedList_ReturnsSortedList()
        {
            List<int> list = new List<int> { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
            TurboSort.SelectionSort(list);
            CollectionAssert.AreEqual(new List<int> { 1, 1, 2, 3, 3, 4, 5, 5, 5, 6, 9 }, list);
        }
    }
}