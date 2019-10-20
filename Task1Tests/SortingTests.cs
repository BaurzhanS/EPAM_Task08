using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Tests
{
    [TestClass()]
    public class SortingTests
    {
        private int[][] JaggedArray = new int[][]
        {
            new int[] {1,3,5,7,9},
            new int[] {11,22},
            new int[] {0,2,4,6}
        };

        [TestMethod]
        public void BubbleSortByRows_AscSortingBySumOfMembers_ReturnsSortedArray()
        {
            int[][] arr = (int[][])JaggedArray.Clone();
            int[][] expectedArray = new int[][]
            {
                new int[] {0,2,4,6},
                new int[] {1,3,5,7,9},
                new int[] {11,22}
            };

            Sorting.BubbleSortByRows(arr, new AscendingCompBySum());

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Assert.AreEqual(arr[i][j], expectedArray[i][j]);
                }
            }
        }

        [TestMethod]
        public void BubbleSortByRows_DescSortingBySumOfMembers_ReturnsSortedArray()
        {
            int[][] arr = (int[][])JaggedArray.Clone();
            int[][] expectedArray = new int[][]
            {
                new int[] {11,22},
                new int[] {1,3,5,7,9},
                new int[] {0,2,4,6}
            };

            Sorting.BubbleSortByRows(arr, new DescendingCompBySum());

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Assert.AreEqual(arr[i][j], expectedArray[i][j]);
                }
            }
        }

        [TestMethod]
        public void BubbleSortByRows_AscSortingByMin_ReturnsSortedArray()
        {
            int[][] arr = (int[][])JaggedArray.Clone();
            int[][] expectedArray = new int[][]
            {
                new int[] {0,2,4,6},
                new int[] {1,3,5,7,9},
                new int[] {11,22},
            };

            Sorting.BubbleSortByRows(arr, new AscendingCompByMinMember());

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Assert.AreEqual(arr[i][j], expectedArray[i][j]);
                }
            }
        }

        [TestMethod]
        public void BubbleSortByRows_DescSortingByMin_ReturnsSortedArray()
        {
            int[][] arr = (int[][])JaggedArray.Clone();
            int[][] expectedArray = new int[][]
            {
                new int[] {11,22},
                new int[] {1,3,5,7,9},
                new int[] {0,2,4,6}
            };

            Sorting.BubbleSortByRows(arr, new DescendingCompByMinMember());

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Assert.AreEqual(arr[i][j], expectedArray[i][j]);
                }
            }
        }

        [TestMethod]
        public void BubbleSortByRows_AscSortingByMaxMember_ReturnsSortedArray()
        {
            int[][] arr = (int[][])JaggedArray.Clone();
            int[][] expectedArray = new int[][]
            {
                new int[] {0,2,4,6},
                new int[] {1,3,5,7,9},
                new int[] {11,22}
            };

            Sorting.BubbleSortByRows(arr, new AscendingCompByMaxMember());

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Assert.AreEqual(arr[i][j], expectedArray[i][j]);
                }
            }
        }

        [TestMethod]
        public void BubbleSortByRows_DescSortingByMaxMember_ReturnsSortedArray()
        {
            int[][] arr = (int[][])JaggedArray.Clone();
            int[][] expectedArray = new int[][]
            {
                new int[] {11,22},
                new int[] {1,3,5,7,9},
                new int[] {0,2,4,6},
            };

            Sorting.BubbleSortByRows(arr, new DescendingCompByMaxMember());

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Assert.AreEqual(arr[i][j], expectedArray[i][j]);
                }
            }
        }

        [TestMethod]
        public void BubbleSortByRows_AscSortingByLength_ReturnsSortedArray()
        {
            int[][] arr = (int[][])JaggedArray.Clone();
            int[][] expectedArray = new int[][]
            {
                new int[] {11,22},
                new int[] {0,2,4,6},
                new int[] {1,3,5,7,9}
            };

            Sorting.BubbleSortByRows(arr, new AscendingCompByLength());

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Assert.AreEqual(arr[i][j], expectedArray[i][j]);
                }
            }
        }

        [TestMethod]
        public void BubbleSortByRows_DescSortingByLength_ReturnsSortedArray()
        {
            int[][] arr = (int[][])JaggedArray.Clone();
            int[][] expectedArray = new int[][]
            {
                new int[] {1,3,5,7,9},
                new int[] {0,2,4,6},
                new int[] {11,22}
            };

            Sorting.BubbleSortByRows(arr, new DescendingCompByLength());

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Assert.AreEqual(arr[i][j], expectedArray[i][j]);
                }
            }
        }

        [TestMethod]
        public void BubbleSortByRows_AscSortingByFirstMember_ReturnsSortedArray()
        {
            int[][] arr = (int[][])JaggedArray.Clone();
            int[][] expectedArray = new int[][]
            {
                new int[] {0,2,4,6},
                new int[] {1,3,5,7,9},
                new int[] {11,22},
            };

            Sorting.BubbleSortByRows(arr, new AscendingCompByFirstMember());

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Assert.AreEqual(arr[i][j], expectedArray[i][j]);
                }
            }
        }

        [TestMethod]
        public void BubbleSortByRows_DescSortingByFirstMember_ReturnsSortedArray()
        {
            int[][] arr = (int[][])JaggedArray.Clone();
            int[][] expectedArray = new int[][]
            {
                new int[] {11,22},
                new int[] {1,3,5,7,9},
                new int[] {0,2,4,6}
            };

            Sorting.BubbleSortByRows(arr, new DescendingCompByFirstMember());

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Assert.AreEqual(arr[i][j], expectedArray[i][j]);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BubbleSortByRows_EmptyString_ThrowsArgumentException()
        {
            int[][] arr = new int[][]
            {
                new int[] {0,2,4,6},
                new int[] {},
                new int[] {11,22},
            };

            Sorting.BubbleSortByRows(arr, new AscendingCompByMinMember());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BubbleSortByRows_NullString_ThrowsArgumentNullException()
        {
            int[][] arr = new int[3][];
            arr[0] = new int[] { 1, 2 };

            Sorting.BubbleSortByRows(arr, new AscendingCompByMinMember());
        }
    }

}