namespace Algorithms
{
    public static class SortExtensions
    {
        #region Bubble sort
        public static void BubbleSort<T>(this IList<T> arr, int start, int end) where T : IComparable<T>
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

        public static void BubbleSort<T>(this IList<T> arr) where T : IComparable<T>
        {
            BubbleSort<T>(arr, 0, arr.Count - 1);
        }
        #endregion

        #region Quick sort
        private static int Partinition<T>(IList<T> arr, int start, int end) where T : IComparable<T>
        {
            T pivot = arr[start];
            while (true)
            {

                while (arr[start].CompareTo(pivot) < 0)
                {
                    start++;
                }

                while (arr[end].CompareTo(pivot) > 0)
                {
                    end--;
                }

                if (start < end)
                {
                    if (arr[start].CompareTo(arr[end]) == 0) return end;

                    (arr[start], arr[end]) = (arr[end], arr[start]);
                }
                else
                {
                    return end;
                }
            }
        }

        public static void QuickSort<T>(this IList<T> arr, int start, int end) where T : IComparable<T>
        {
            if (start >= end) return;

            int pivot = Partinition(arr, start, end);
            QuickSort(arr, start, pivot - 1);
            QuickSort(arr, pivot + 1, end);
        }

        public static void QuickSort<T>(this IList<T> arr) where T : IComparable<T>
        {
            QuickSort(arr, 0, arr.Count - 1);
        }
        #endregion
    }
}
