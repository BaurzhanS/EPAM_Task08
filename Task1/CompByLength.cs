using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class AscendingCompByLength : IComparer<int[]>
    {
        public void CheckInputArray(int[] arr1, int[] arr2)
        {
            if (arr1 == null || arr2 == null)
                throw new ArgumentNullException();
            if (arr1.Length == 0 || arr2.Length == 0)
                throw new ArgumentException();
        }

        public int Compare(int[] arr1, int[] arr2)
        {
            CheckInputArray(arr1, arr2);
            return arr1.Length - arr2.Length;
        }
    }

    public class DescendingCompByLength : IComparer<int[]>
    {
        public void CheckInputArray(int[] arr1, int[] arr2)
        {
            if (arr1 == null || arr2 == null)
                throw new ArgumentNullException();
            if (arr1.Length == 0 || arr2.Length == 0)
                throw new ArgumentException();
        }

        public int Compare(int[] arr1, int[] arr2)
        {
            CheckInputArray(arr1, arr2);
            return arr2.Length - arr1.Length;
        }
    }
}
