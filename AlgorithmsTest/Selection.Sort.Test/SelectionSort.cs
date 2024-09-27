using System;
using System.Collections.Generic;

namespace TurboCollections
{
    public static class TurboSort
    {
        public static void SelectionSort(List<int> list)
        {
            int n = list.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                // Find the minimum element in the unsorted list
                for (int j = i + 1; j < n; j++)
                {
                    if (list[j] < list[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Swap the minimum element with the current element
                if (minIndex != i)
                {
                    (list[i], list[minIndex]) = (list[minIndex], list[i]);
                }
            }
        }
    }
}