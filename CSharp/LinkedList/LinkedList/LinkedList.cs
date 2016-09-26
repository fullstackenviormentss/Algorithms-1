using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class LinkedList<T> : Node<T>, IEnumerable<T>, ILinkedList<T>
    {
        public LinkedList() : base() { }

        public LinkedList(T data) : base(data) { }

        public LinkedList(Node<T> head) :  base(head.Data, head.Next) { }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Node<T> Append(T data)
        {
            throw new NotImplementedException();
        }

        public Node<T> Append(Node<T> node)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Node<T> InsertAt(T data, int position)
        {
            throw new NotImplementedException();
        }

        public Node<T> InsertAt(Node<T> node, int position)
        {
            throw new NotImplementedException();
        }

        public Node<T> Remove(T data)
        {
            throw new NotImplementedException();
        }

        public Node<T> Remove(Node<T> node)
        {
            throw new NotImplementedException();
        }

        public Node<T> RemoveAll(T data)
        {
            throw new NotImplementedException();
        }

        public Node<T> RemoveAt(int position)
        {
            throw new NotImplementedException();
        }

        public Node<T> RemoveFirst(T data)
        {
            throw new NotImplementedException();
        }

        public Node<T> RemoveLast(T data)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
