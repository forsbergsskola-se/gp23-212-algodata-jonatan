﻿
using System;
using System.Collections.Generic;

namespace TurboCollections
{
    public static partial class TurboSort
    {
        // Método de ordenación por selección
        public static void SelectionSort(List<int> list)
        {
            int n = list.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (list[j] < list[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    (list[i], list[minIndex]) = (list[minIndex], list[i]);
                }
            }
        }
    }
}