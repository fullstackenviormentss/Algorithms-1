using System.IO;

namespace LinkedList
{
    public interface ILinkedList<T>
    {
        INode<T> Append(T data);
        INode<T> Append(INode<T> node);

        INode<T> InsertAt(T data, int index);
        INode<T> InsertAt(INode<T> node, int index);

        INode<T> RemoveFirst();
        INode<T> RemoveFirst(T data);

        INode<T> RemoveLast();
        INode<T> RemoveLast(T data);

        INode<T> RemoveAll(T data);
        
        INode<T> RemoveAt(int index);

        void Clear();
        void Print(TextWriter w = null);

        int Count { get; }
    }
}