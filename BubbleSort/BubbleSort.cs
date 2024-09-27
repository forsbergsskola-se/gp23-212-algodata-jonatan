
using System;
using System.Collections.Generic;

namespace TurboCollections
{
    public static partial class TurboSort
    {
        public static void BubbleSort(List<int> list)
        {
            int n = list.Count;
            bool swapped;
            
            do
            {
                swapped = false;
                for (int i = 0; i < n - 1; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        (list[i], list[i + 1]) = (list[i + 1], list[i]);
                        swapped = true;
                    }
                }
                
                n--;
            } while (swapped);
        }
    }
}