namespace LinkedList
{
    public interface ILinkedList<T>
    {
        Node<T> Append(Node<T> node);
        Node<T> Append(T data);

        Node<T> InsertAt(Node<T> node, int position);
        Node<T> InsertAt(T data, int position);

        Node<T> Remove(Node<T> node);
        Node<T> Remove(T data);
        Node<T> RemoveAll(T data);
        Node<T> RemoveFirst(T data);
        Node<T> RemoveLast(T data);
        
        Node<T> RemoveAt(int position);

        int Count { get; }
    }
}