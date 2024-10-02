namespace Algorithms
{
    public static class Sorting
    {
        public static IEnumerable<T> MergeSort<T>(IEnumerable<T> array)
            where T: IComparable
        {
            throw new NotImplementedException();
        }

        private static void MergeSort<T>(IList<T> array)
            where T: IComparable
        {
            throw new NotImplementedException();
        }

        public static IList<T> QuickSort<T>(IList<T> array)
            where T: IComparable
        {
            QuickSort(array, 0, array.Count - 1);
            return array;
        }

        private static void QuickSort<T>(IList<T> array, int left, int right)
            where T: IComparable
        {
            if (right <= left)
                return;

            var pivot = array[left];
            var i = left;
            var j = right;
            while (i <= j)
            {
                while (array[i].CompareTo(pivot) < 0) i++;
                while (array[j].CompareTo(pivot) > 0) j--;
                if (i <= j)
                {
                    (array[j], array[i]) = (array[i], array[j]);
                    i++;
                    j--;
                }
            }

            QuickSort(array, left, j);
            QuickSort(array, i, right);
        }
    }
}
