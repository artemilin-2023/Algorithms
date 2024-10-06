using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace DataStructures
{
    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IEnumerable<KeyValuePair<TKey, TValue>>, ICollection<KeyValuePair<TKey, TValue>>
    {

        public ICollection<TKey> Keys => buckets.SelectMany(b => b.Select(i => i.Key)).ToList();
        public ICollection<TValue> Values => buckets.SelectMany(b => b.Select(i => i.Value)).ToList();
        public int Count { get; private set; }
        public bool IsReadOnly => false;
        public TValue this[TKey key]
        {
            get
            {
                if (TryGetValue(key, out var value))
                    return value;
                throw new ArgumentException($"По ключу {key} не удалось получить значение.");
            }

            set
            {
                if (!TryInsert(key, value))
                    Add(key, value);
            }
        }

        private const int MaxLoadFacotr = 3;
        private const int MinLoadFactor = 1;
        private const int InitialSize = 5;

        private List<KeyValuePair<TKey, TValue>>[] buckets;
        private int Size => buckets.Length;
        private int LoadFactor => Count / Size;
        private bool NeedResizing => LoadFactor > MaxLoadFacotr || LoadFactor < MinLoadFactor && Size > InitialSize;

        public MyDictionary()
        {
            buckets = new List<KeyValuePair<TKey, TValue>>[InitialSize];
            InitializeBuckets(InitialSize, buckets);
            Count = 0;
        }

        private void InitializeBuckets(int size, List<KeyValuePair<TKey, TValue>>[] array)
        {
            for (int i = 0; i < size; i++)
                array[i] = new List<KeyValuePair<TKey, TValue>>();
        }

        private bool TryInsert(TKey key, TValue value)
        {
            ArgumentNullException.ThrowIfNull(key);

            var bucket = buckets[GetBucket(key, Size)];
            for (int i = 0; i < bucket.Count; i++)
            {
                if (bucket[i].Key!.Equals(key))
                {
                    bucket[i] = new KeyValuePair<TKey, TValue>(key, value);
                    return true;
                }
            }
            return false;
        }

        public void Add(TKey key, TValue value)
            => Add(new KeyValuePair<TKey, TValue>(key, value));

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            ArgumentNullException.ThrowIfNull(item.Key);
            if (ContainsKey(item.Key))
                throw new ArgumentException($"Элемент с ключем {item.Key} уже добавлен.");

            if (NeedResizing)
                ResizeTable();

            var index = GetBucket(item.Key, Size);
            buckets[index].Add(item);
            Count++;
        }

        private void ResizeTable()
        {
            var newSize = LoadFactor > MaxLoadFacotr ? Size * 2 : Size / 2;
            var newBuckets = new List<KeyValuePair<TKey, TValue>>[newSize];
            InitializeBuckets(newSize, newBuckets);

            foreach (var bucket in buckets)
            {
                foreach(var item in bucket)
                {
                    var index = GetBucket(item.Key, newSize);
                    newBuckets[index].Add(item); 
                }
            }

            buckets = newBuckets;
        }

        private int GetBucket(TKey key, int size) 
            => Math.Abs(key!.GetHashCode() % size);

        public void Clear()
        {
            Array.Clear(buckets, 0, buckets.Length);
            Count = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            ArgumentNullException.ThrowIfNull(item.Key);

            var index = GetBucket(item.Key, Size);
            foreach (var pair in buckets[index])
            {
                if (pair.Equals(item)) 
                    return true;
            }
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            ArgumentNullException.ThrowIfNull(key);

            var index = GetBucket(key, Size);
            foreach (var item in buckets[index])
            {
                if (item.Key!.Equals(key))
                    return true;
            }
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array)
            => CopyTo(array, 0);

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ArgumentNullException.ThrowIfNull(array);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(arrayIndex, array.Length - 1);
            ArgumentOutOfRangeException.ThrowIfNegative(arrayIndex);
            if (array.Length - arrayIndex < Count)
                throw new ArgumentException("Размерности массива недостаточно для копирования всех элементов.");

            var i = arrayIndex;
            foreach (var bucket in buckets)
            {
                foreach (var item in bucket)
                {
                    array[i++] = item;
                }
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
            => buckets.SelectMany(b => b.Select(i => i)).GetEnumerator();

        public bool Remove(TKey key)
        {
            ArgumentNullException.ThrowIfNull(key);

            var bucket = buckets[GetBucket(key, Size)];
            for (var i = 0; i < bucket.Count; i++)
            {
                if (bucket[i].Key!.Equals(key))
                {
                    bucket.RemoveAt(i);
                    Count--;
                    return true;
                }
            }
            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
            => Remove(item.Key);

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            ArgumentNullException.ThrowIfNull(key);
            value = default(TValue);

            var index = GetBucket(key, Size);
            foreach (var item in buckets[index])
            {
                if (item.Key!.Equals(key))
                {
                    value = item.Value;
                    return true;
                }
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
