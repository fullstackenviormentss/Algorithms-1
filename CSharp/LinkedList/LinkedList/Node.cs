namespace LinkedList
{
    public class Node<T>
    {
        protected Node() { }

        public Node(T data, Node<T> next = null)
        {
            Data = data;
            Next = next;
        }

        public T Data { get; set; }

        public Node<T> Next { get; set; }
    }
}
