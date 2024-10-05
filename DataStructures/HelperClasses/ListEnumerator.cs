using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HelperClasses
{
    internal class ListEnumerator<T> : IEnumerator<T>
    {
        private readonly ListNode<T> head;
        private ListNode<T>? current;

        public ListEnumerator(ListNode<T> head)
        {
            this.head = head;
        }

        public T Current
        {
            get
            {
                ArgumentNullException.ThrowIfNull(current);
                return current.Data!;
            }
        }

        object IEnumerator.Current => Current!;

        public void Dispose() { }

        public bool MoveNext()
        {
            if (head == null)
                return false;

            if (current == null)
            {
                current = head;
                return true;
            }
            else if (current!.Next != null)
            {
                current = current.Next;
                return true;
            }
            return false;
        }

        public void Reset() => current = head;
    }
}
