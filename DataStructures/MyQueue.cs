using DataStructures.HelperClasses;
using System.Collections;

namespace DataStructures
{
    public class MyQueue<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        public bool IsReadOnly => false;
        public bool IsSynchronized => false;
        public object SyncRoot => new object();

        private ListNode<T>? head = null;
        private ListNode<T>? tail = null;

        public MyQueue()
        {
            Count = 0;
        }

        public void Enqueue(T value)
        {
            if (head == null && tail == null)
            {
                AddFirstNode(value);
            }
            else
            {
                AddNode(value);
            }

            Count++;
        }

        private void AddFirstNode(T value)
        {
            var newNode = new ListNode<T>(null, value);

            head = newNode;
            tail = newNode;
        }

        private void AddNode(T value)
        {
            var newNode = new ListNode<T>(null, value);

            tail!.Next = newNode;
            tail = newNode;
        }

        public T Dequeue()
        {
            if (QueueIsEmpty())
                throw new InvalidOperationException();

            Count--;
            if (head == tail)
                return ExctractLastElement();
            return ExtractElement();
        }

        private bool QueueIsEmpty() 
            => Count == 0;

        private T ExctractLastElement()
        {
            var result = head!.Data;

            head = null;
            tail = null;

            return result!;
        }

        private T ExtractElement()
        {
            var result = head!.Data;

            head = head.Next;

            return result!;
        }

        public T Peek()
        {
            if (QueueIsEmpty())
                throw new InvalidOperationException();

            return head!.Data!;
        }

        public bool Contains(T item)
        {
            if (QueueIsEmpty())
                return false;

            var current = head;

            while (current != null)
            {
                if (current!.Data!.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator() => new ListEnumerator<T>(head);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void CopyTo(T[] array) 
            => CopyTo(array, 0);

        public void CopyTo(T[] array, int index)
        {
            ArgumentNullException.ThrowIfNull(array);
            ArgumentOutOfRangeException.ThrowIfLessThan(index, 0);

            var currentNode = head;
            for (int i = index; i < array.Length; i++)
            {
                if (currentNode == null)
                    break;

                array[i] = currentNode.Data!;
                currentNode = currentNode.Next;
            }

            if (currentNode != null)
                throw new ArgumentException("Не удалось полностью скопировать исходную очередь.");
        }
    }
}
