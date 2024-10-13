namespace Algorithms
{
    public static class Searcher
    {
        /// <summary>
        /// Ищет первое вхождение элемента в массиве и возвращает его индекс. Если элемент не найден, возвращает -1.
        /// </summary>
        /// <typeparam name="T">Тип элемента в масссиве, реализующий интерфейс <see cref="IEquatable{T}"/></typeparam>
        /// <param name="array">Массив, в котором будет осуществляться поиск. Может быть неотсортированным.</param>
        /// <param name="target">Искомый элемент.</param>
        /// <returns>Индекс элемента. -1, если искомого элемента нет в массиве.</returns>
        public static int LinearSearch<T>(this IList<T> array, T target)
            where T: IEquatable<T>
        {
            for (var i = 0; i < array.Count; i++)
            {
                if (array[i].Equals(target))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Ищет первое вхождение элемента в массиве и возвращает его индекс. Если элемент не найден, возвращает -1.
        /// </summary>
        /// <typeparam name="T">Тип элемента в масссиве, реализующий интерфейс <see cref="IEquatable{T}"/></typeparam>
        /// <param name="array">Массив, в котором будет осуществляться поиск. Может быть неотсортированным.</param>
        /// <param name="target">Искомый элемент.</param>
        /// <returns>Индекс элемента. -1, если искомого элемента нет в массиве.</returns>
        public static int SentinelSearch<T>(this IList<T> array, T target)
            where T: IEquatable<T>
        {
            var tmp = array[array.Count - 1];
            array[array.Count - 1] = target;

            int i = 0;
            while (!array[i].Equals(target))
                i++;

            array[array.Count - 1] = tmp;
            if (i < array.Count - 1 || array[array.Count - 1].Equals(target))
                return i;
            return -1;
        }

        /// <summary>
        /// Ищет первое вхождение элемента в отсортированном по возрастанию массиве и возвращает его индекс. Если элемент не найден, возвращает -1.
        /// </summary>
        /// <typeparam name="T">Тип элемента в масссиве, реализующий интерфейс <see cref="IComparable"/></typeparam>
        /// <param name="array">Отсортированный по возрастанию массив, в котором будет осуществляться поиск.</param>
        /// <param name="target">Искомый элемент.</param>
        /// <returns>Индекс элемента. -1, если искомого элемента нет в массиве.</returns>
        public static int BinarySearch<T>(this IList<T> sortedArray, T target)
            where T: IComparable
        {
            var left = 0;
            var right = sortedArray.Count - 1;
            while (left < right)
            {
                var middle = (left + right) / 2;
                if (sortedArray[middle].CompareTo(target) == 0)
                {
                    return middle;
                }
                else if (sortedArray[middle].CompareTo(target) > 0)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }
            return -1;
        }
    }
}
