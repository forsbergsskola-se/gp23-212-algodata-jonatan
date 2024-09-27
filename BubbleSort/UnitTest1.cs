using NUnit.Framework;
using System.Collections.Generic;
using TurboCollections;

namespace TurboCollections.Tests
{
    public class TurboSortTests
    {
        [Test]
        public void SelectionSort_SortsListCorrectly()
        {
            // Arrange
            List<int> unsortedList = new List<int> { 5, 3, 8, 4, 2 };
            List<int> expectedList = new List<int> { 2, 3, 4, 5, 8 };

            // Act
            TurboSort.SelectionSort(unsortedList);

            // Assert
            Assert.AreEqual(expectedList, unsortedList);
        }

        [Test]
        public void BubbleSort_SortsListCorrectly()
        {
            // Arrange
            List<int> unsortedList = new List<int> { 5, 3, 8, 4, 2 };
            List<int> expectedList = new List<int> { 2, 3, 4, 5, 8 };

            // Act
            TurboSort.BubbleSort(unsortedList);

            // Assert
            Assert.AreEqual(expectedList, unsortedList);
        }

        [Test]
        public void SelectionSort_EmptyList()
        {
            // Arrange
            List<int> emptyList = new List<int>();

            // Act
            TurboSort.SelectionSort(emptyList);

            // Assert
            Assert.IsEmpty(emptyList);
        }

        [Test]
        public void BubbleSort_EmptyList()
        {
            // Arrange
            List<int> emptyList = new List<int>();

            // Act
            TurboSort.BubbleSort(emptyList);

            // Assert
            Assert.IsEmpty(emptyList);
        }

        [Test]
        public void SelectionSort_SingleElement()
        {
            // Arrange
            List<int> singleElementList = new List<int> { 1 };

            // Act
            TurboSort.SelectionSort(singleElementList);

            // Assert
            Assert.AreEqual(new List<int> { 1 }, singleElementList);
        }

        [Test]
        public void BubbleSort_SingleElement()
        {
            // Arrange
            List<int> singleElementList = new List<int> { 1 };

            // Act
            TurboSort.BubbleSort(singleElementList);

            // Assert
            Assert.AreEqual(new List<int> { 1 }, singleElementList);
        }
    }
}