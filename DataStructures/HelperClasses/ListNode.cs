namespace DataStructures.HelperClasses
{
    internal class ListNode<T>(ListNode<T>? next, T data) : BaseNode<T>(data)
    {
        internal ListNode<T>? Next { get; set; } = next;
    }
}
