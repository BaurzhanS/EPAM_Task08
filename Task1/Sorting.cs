using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class Sorting
    {
        public static void BubbleSortByRows(int[][] arr, IComparer<int[]> comparer)
        {
            CheckInputArray(arr);

            BubbleSortByRows(arr, comparer.Compare);
        }

        public static void BubbleSortByRows(int[][] arr, Comparison<int[]> comparer)
        {
            CheckInputArray(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (comparer(arr[j], arr[j + 1]) > 0)
                    {
                        int[] temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static void CheckInputArray(int[][] arr)
        {
            if (arr == null)
                throw new ArgumentNullException();

            if (arr.Length == 0)
                throw new ArgumentException();
        }
    }
}
