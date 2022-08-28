﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class SearchExtensions
    {
        #region BinarySearch
        public static int BinarySearch<T>(this IList<T> array, T item, int start, int end) where T : IComparable<T>
        {
            if (start > end) return -1;

            while (start <= end)
            {
                int middle = (end + start) / 2;
                int res = item.CompareTo(array[middle]);
                switch (res)
                {
                    case -1:
                        end = middle - 1;
                        break;
                    case 0:
                        return middle;
                    case 1:
                        start = middle + 1;
                        break;
                }
            }
            return -1;
        }

        public static int BinarySearch<T>(this IList<T> array, T item) where T : IComparable<T>
        {
            return BinarySearch<T>(array, item, 0, array.Count);
        }
        #endregion
    }
}