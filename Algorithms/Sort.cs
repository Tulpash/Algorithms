namespace Algorithms
{
    public static class Sort
    {
        #region Bubble sort
        public static void BubbleSort<T>(IList<T> arr, int start, int end) where T : IComparable<T>
        {
            if (start >= end) return;

            for (int i = start; i < end; i++)
            {
                for (int j = start; j < end - i; j++)
                {
                    int res = arr[j].CompareTo(arr[j + 1]);
                    if (res > 0)
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
            }
        }

        public static void BubbleSort<T>(IList<T> arr) where T : IComparable<T>
        {
            BubbleSort<T>(arr, 0, arr.Count - 1);
        }
        #endregion

        #region Quick sort
        private static int Partinition<T>(IList<T> arr, int start, int end) where T : IComparable<T>
        {
            var pivot = start - 1;
            for (var i = start; i < end; i++)
            {
                if (arr[i].CompareTo(arr[end]) < 0)
                {
                    pivot++;
                    (arr[pivot], arr[i]) = (arr[i], arr[pivot]);
                }
            }

            pivot++;
            (arr[pivot], arr[end]) = (arr[end], arr[pivot]);
            return pivot;
        }

        public static void QuickSort<T>(IList<T> arr, int start, int end) where T : IComparable<T>
        {
            if (start >= end) return;

            int pivot = Partinition(arr, start, end);
            QuickSort(arr, start, pivot - 1);
            QuickSort(arr, pivot + 1, end);
        }

        public static void QuickSort<T>(IList<T> arr) where T : IComparable<T>
        {
            QuickSort(arr, 0, arr.Count - 1);
        }
        #endregion

        #region Pancake sort
        private static void Reverse<T>(this IList<T> arr, int start, int end)
        {
            for (; start < end; start++, end--)
            {
                (arr[start], arr[end]) = (arr[end], arr[start]);
            }
        }

        private static int IndexOfMax<T>(this IList<T> arr, int start, int end) where T : IComparable<T>
        {
            int res = start++;

            for (; start <= end; start++)
            {
                if (arr[start].CompareTo(arr[res]) > 0)
                    res = start;
            }

            return res;
        }

        public static void PancakeSort<T>(IList<T> arr, int start, int end) where T : IComparable<T> 
        {
            for (var unsorted = end; unsorted >= start; unsorted--)
            {
                var max = arr.IndexOfMax(0, unsorted);
                if (max.CompareTo(unsorted) != 0)
                {
                    arr.Reverse(0, max);
                    arr.Reverse(0, unsorted);
                }
            }

        }

        public static void PancakeSort<T>(IList<T> arr) where T : IComparable<T>
        {
            PancakeSort(arr, 0, arr.Count - 1);
        }
        #endregion

        #region Shake sort
        public static void ShakeSort<T>(IList<T> arr, int start, int end) where T : IComparable<T>
        {
            for (int i = start; i < (end - start) / 2; i++)
            {
                bool isSwapped = false;

                for (int j = i; j < end - i; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        isSwapped = true;
                    }
                }

                for (int j = end - i - 1; j > i; j--)
                {
                    if (arr[j - 1].CompareTo(arr[j]) > 0)
                    {
                        (arr[j], arr[j - 1]) = (arr[j - 1], arr[j]);
                        isSwapped = true;
                    }
                }

                if (!isSwapped) break;
            }
        }

        public static void ShakeSort<T>(IList<T> arr) where T : IComparable<T>
        {
            ShakeSort(arr, 0, arr.Count - 1);
        }
        #endregion

        #region Bogo sort
        private static void Permutation<T>(IList<T> arr, int start, int end)
        {
            Random rnd = new Random();
            int i = end;
            while (i > start)
            {
                int n = rnd.Next(start, i + 1);
                (arr[i], arr[n]) = (arr[n], arr[i]);
                i--;
            }
        }

        private static bool IsSorted<T>(IList<T> arr, int start, int end) where T : IComparable<T>
        {
            for (; start < end; start++)
            {
                if (arr[start].CompareTo(arr[start + 1]) > 0) return false;
            }

            return true;
        }

        public static void BogoSort<T>(IList<T> arr, int start, int end) where T : IComparable<T>
        {
            while (IsSorted(arr, start, end))
            {
                Permutation(arr, start, end);
            }
        }

        public static void BogoSort<T>(IList<T> arr) where T : IComparable<T>
        {
            BogoSort(arr, 0, arr.Count - 1);
        }
        #endregion
    }
}
