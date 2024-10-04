namespace Algorithms
{
    public static class Sorting
    {
        public static IList<T> MergeSort<T>(this IList<T> array)
            where T: IComparable
        {
            MergeSort(array, 0, array.Count - 1);
            return array;
        }

        private static void MergeSort<T>(IList<T> array, int startIndex, int endIndex)
            where T: IComparable
        {
            if (endIndex <= startIndex)
                return;

            var centerIndex = (startIndex + endIndex) / 2;
            MergeSort(array, startIndex, centerIndex);
            MergeSort(array, centerIndex + 1, endIndex);
            Merge(array, startIndex, centerIndex, endIndex);
        }

        private static void Merge<T>(IList<T> array, int startIndex, int centerIndex, int endIndex)
            where T: IComparable
        {
            var left = startIndex;
            var right = centerIndex + 1; // Центральный элемент не включается в правую часть
            var mergedArray = new T[endIndex - startIndex + 1];

            var index = 0;
            while (left <= centerIndex && right <= endIndex)
            {
                if (array[left].CompareTo(array[right]) < 0)
                {
                    mergedArray[index] = array[left];
                    left++;
                }
                else
                {
                    mergedArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (int i = left; i <= centerIndex; i++) 
            {
                mergedArray[index] = array[i];
                index++;
            }
            for (int i = right; i <= endIndex; i++)
            {
                mergedArray[index] = array[i];
                index++;
            }

            // Заменяем элементы исходного массива
            for (int i = 0; i < mergedArray.Length; i++)
            {
                array[startIndex + i] = mergedArray[i];
            }
        }

        public static IList<T> QuickSort<T>(this IList<T> array)
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
                    Swap(array, i, j);
                    i++;
                    j--;
                }
            }

            QuickSort(array, left, j);
            QuickSort(array, i, right);
        }

        private static void Swap<T>(IList<T> array, int i, int j)
        {
            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }

        public static IList<T> BubbleSort<T>(this IList<T> array)
            where T: IComparable
        {
            for (int i = 0; i < array.Count - 1; i++) 
            {
                for (int j = i + 1; j < array.Count; j++)
                {
                    if (array[i].CompareTo(array[j]) > 0)
                        Swap(array, i, j);
                }
            }
            return array;
        }

        public static IList<T> InsertSort<T>(this IList<T> array)
            where T: IComparable
        {
            for (var sortedIndex = 0;  sortedIndex < array.Count - 1; sortedIndex++)
            {
                Insert(array, sortedIndex, sortedIndex + 1);
            }
            return array;
        }

        private static void Insert<T>(IList<T> array, int sortedIndex, int itemIndex)
            where T: IComparable
        {
            var insertIndex = GetInsertIndex(array, sortedIndex, array[itemIndex]);

            for (var i = itemIndex; i > insertIndex; i--)
            {
                Swap(array, i, i - 1);
            }
        }

        private static int GetInsertIndex<T>(IList<T> array, int sortedIndex, T value)
            where T: IComparable
        {
            var leftBorder = 0;
            var rightBorder = sortedIndex;
            while (leftBorder <= rightBorder)
            {
                var midle = (rightBorder + leftBorder) / 2;
                if (value.CompareTo(array[midle]) == 0)
                {
                    return midle;
                }
                else if (value.CompareTo(array[midle]) > 0)
                {
                    leftBorder = midle + 1;
                }
                else
                {
                    rightBorder = midle - 1;
                }
            }
            return rightBorder + 1;
        }

        public static IList<T> SelectedSort<T>(this IList<T> array)
            where T : IComparable
        {
            for (int i = 0; i < array.Count - 1; i++)
            {
                var min = array[i];
                var minIndex = i;
                for (int j = i + 1; j < array.Count; j++)
                {
                    if (array[j].CompareTo(min) < 0)
                    {
                        min = array[j];
                        minIndex = j;
                    }
                }
                Swap(array, i, minIndex);
            }
            return array;
        }
    }
}
