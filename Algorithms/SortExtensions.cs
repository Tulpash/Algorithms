namespace Algorithms
{
    public static class SortExtensions
    {
        #region Validation
        private static void ValidArray<T>(IList<T> arr, int start, int end)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));

            if (start > arr.Count || start < 0)
                throw new ArgumentOutOfRangeException(nameof(start), "The value must be within the array boundaries");

            if (end > arr.Count || end < 0)
                throw new ArgumentOutOfRangeException(nameof(end), "The value must be within the array boundaries");

            if (start > end)
                throw new ArgumentException($"{nameof(start)} should be less or equal than {nameof(end)}");
        }
        #endregion

        #region Bubble sort
        public static void BubbleSort<T>(this IList<T> arr, int start, int end) where T : IComparable<T>
        {
            ValidArray(arr, start, end);
            if (start == end) return;

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

        public static void BubbleSort<T>(this IList<T> arr) where T : IComparable<T>
        {
            arr.BubbleSort(0, arr.Count - 1);
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

        public static void QuickSort<T>(this IList<T> arr, int start, int end) where T : IComparable<T>
        {
            ValidArray(arr, start, end);
            if (start == end) return;

            int pivot = Partinition(arr, start, end);
            arr.QuickSort(start, pivot - 1);
            arr.QuickSort(pivot + 1, end);
        }

        public static void QuickSort<T>(this IList<T> arr) where T : IComparable<T>
        {
            arr.QuickSort(0, arr.Count - 1);
        }
        #endregion

        #region Pancake sort
        private static void Reverse<T>(IList<T> arr, int start, int end)
        {
            for (; start < end; start++, end--)
            {
                (arr[start], arr[end]) = (arr[end], arr[start]);
            }
        }

        private static int IndexOfMax<T>(IList<T> arr, int start, int end) where T : IComparable<T>
        {
            int res = start++;

            for (; start <= end; start++)
            {
                if (arr[start].CompareTo(arr[res]) > 0)
                    res = start;
            }

            return res;
        }

        public static void PancakeSort<T>(this IList<T> arr, int start, int end) where T : IComparable<T>
        {
            ValidArray(arr, start, end);
            if (start == end) return;

            for (var unsorted = end; unsorted >= start; unsorted--)
            {
                var max = IndexOfMax(arr, 0, unsorted);
                if (max.CompareTo(unsorted) != 0)
                {
                    Reverse(arr, 0, max);
                    Reverse(arr, 0, unsorted);
                }
            }

        }

        public static void PancakeSort<T>(this IList<T> arr) where T : IComparable<T>
        {
            arr.PancakeSort(0, arr.Count - 1);
        }
        #endregion

        #region Shake sort
        public static void ShakeSort<T>(this IList<T> arr, int start, int end) where T : IComparable<T>
        {
            ValidArray(arr, start, end);
            if (start == end) return;

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

        public static void ShakeSort<T>(this IList<T> arr) where T : IComparable<T>
        {
            arr.ShakeSort(0, arr.Count - 1);
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

        public static void BogoSort<T>(this IList<T> arr, int start, int end) where T : IComparable<T>
        {
            ValidArray(arr, start, end);
            if (start == end) return;

            while (IsSorted(arr, start, end))
            {
                Permutation(arr, start, end);
            }
        }

        public static void BogoSort<T>(this IList<T> arr) where T : IComparable<T>
        {
            arr.BogoSort(0, arr.Count - 1);
        }
        #endregion

        #region Insertion sort
        public static void InsertionSort<T>(this IList<T> arr, int start, int end) where T : IComparable<T>
        {
            ValidArray(arr, start, end);
            if (start == end) return;

            for (int i = start + 1; i <= end; i++)
            {
                int j = i;
                while (j > start && arr[j - 1].CompareTo(arr[j]) > 0)
                {
                    (arr[j - 1], arr[j]) = (arr[j], arr[j - 1]);
                    j--;
                }
            }
        }

        public static void InsertionSort<T>(this IList<T> arr) where T : IComparable<T>
        {
            arr.InsertionSort(0, arr.Count - 1);
        }
        #endregion

        #region Selection sort
        private static int IndexOfMin<T>(IList<T> arr, int start, int end) where T : IComparable<T>
        {
            int res = start++;

            for (; start <= end; start++)
            {
                if (arr[start].CompareTo(arr[res]) < 0)
                    res = start;
            }

            return res;
        }

        private static void SelectionSort<T>(this IList<T> arr, int start, int end) where T : IComparable<T>
        {
            ValidArray(arr, start, end);
            if (start == end) return;

            for (int i = start; i <= end; i++)
            {
                int min = IndexOfMin(arr, i, end);
                (arr[i], arr[min]) = (arr[min], arr[i]);
            }
        }

        private static void SelectionSort<T>(this IList<T> arr) where T : IComparable<T>
        {
            arr.SelectionSort(0, arr.Count - 1);
        }
        #endregion
    }
}
