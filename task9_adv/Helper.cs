using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task9_adv
{
    internal class Helper<T> where T : IComparable
    {
        public static void Swap(ref T num1, ref T num2)
        {
            T temp = num1;
            num1 = num2;
            num2 = temp;
        }
        public static void BubbleSort(T[] array)
        {
            if (array is not null)
            {
                int n = array.Length;
                bool swapped;

                for (int i = 0; i < n - 1; i++)
                {
                    swapped = false;

                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (array[j].CompareTo(array[j + 1]) == 1)
                        {
                            Helper<T>.Swap(ref array[j], ref array[j + 1]);
                            swapped = true;
                        }
                    }

                    // If no swaps were made in the inner loop, break early
                    if (!swapped)
                        break;
                }
            }
        }
    }
}
