using DataStructures.HelperClasses;
using System.Collections;

namespace DataStructures
{
    public class MyList<T> : IList<T>, ICollection<T>, IEnumerable<T>
    {
        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public T this[int index] { get => GetNodeBy(index).Data!; set => GetNodeBy(index).Data = value; }

        private ListNode<T>? head = null;
        private ListNode<T>? tail = null;

        public MyList()
        {
            Count = 0;
        }

        public void Add(T item)
        {
            var newNode = new ListNode<T>(null, item);
            if (tail == null && head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail!.Next = newNode;
                tail = newNode;
            }
            Count++;
        }

        public void Clear()
        {
            Count = 0;
            head = null;
            tail = null;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(T[] array)
            => CopyTo(array, 0);

        public void CopyTo(T[] array, int arrayIndex)
        {
            ArgumentNullException.ThrowIfNull(array);

            var currentNode = GetNodeBy(arrayIndex);
            for (int i = 0; i < array.Length; i++)
            {
                if (currentNode == null)
                    break;

                array[i] = currentNode.Data!;
                currentNode = currentNode.Next;
            }
        }

        private ListNode<T> GetNodeBy(int index)
        { 
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            var currentNode = head;
            for (int i = 0; i < index; i++)
                currentNode = currentNode!.Next;
            return currentNode!;
        }

        public IEnumerator<T> GetEnumerator() => new ListEnumerator<T>(head!);

        public int IndexOf(T item)
        {
            var currentNode = head;
            int i = 0;
            while (currentNode != null)
            {
                if (currentNode.Data!.Equals(item))
                    return i;

                currentNode = currentNode.Next;
                i++;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException();

            var newNode = new ListNode<T>(null, item);
            if (index == 0)
            {
                newNode.Next = head;
                head = newNode;
                return;
            }

            var previewNode = GetNodeBy(index - 1);
            var nextNode = previewNode.Next;
            newNode.Next = nextNode;
            previewNode.Next = newNode;
        }

        public bool Remove(T item)
        {
            if (Count <= 0)
                return false;

            if (Count == 1)
            {
                Clear();
                return true;
            }
            else if (head!.Data!.Equals(item))
            {
                head = head.Next;
                Count--;
                return true;
            }

            var preview = head;
            var current = head!.Next;
            while (current != null)
            {
                if (current.Data!.Equals(item))
                {
                    if (current.Next == null)
                        tail = preview;
                    preview!.Next = current.Next;
                    Count--;
                    return true;
                }
                preview = current;
                current = current.Next;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (Count == 1)
            {
                Clear();
                return;
            }

            if (index == 0 && head != null)
            {
                head = head.Next;
                Count--;
                return;
            }

            var previewNode = GetNodeBy(index - 1);
            previewNode.Next = previewNode.Next!.Next;
            if (index == Count - 1)
            {
                tail = previewNode;
            }

            Count--;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
