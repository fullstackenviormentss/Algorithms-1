namespace LinkedList
{
    public class Node<T> : INode<T>
    {
        protected Node() { }

        public Node(T data, INode<T> next = null)
        {
            Data = data;
            Next = next;
        }

        public T Data { get; set; }

        public INode<T> Next { get; set; }
    }
}
