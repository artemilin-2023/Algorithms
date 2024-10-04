namespace DataStructures.HelperClasses
{
    internal abstract class BaseNode<T>
    {
        internal T? Data { get; set; }

        protected BaseNode() { }

        public BaseNode(T? data)
        {
            Data = data;
        }
    }
}
