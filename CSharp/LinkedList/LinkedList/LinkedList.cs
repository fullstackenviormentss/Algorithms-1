using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace LinkedList
{
    // I am still thinking about thread-safety
    // For details, please see my question at: http://codereview.stackexchange.com/questions/142569/would-my-linkedlist-be-thread-safe-if-i-did-not-protect-concurrent-reads-to-its/142573
    // Permalink: http://codereview.stackexchange.com/q/142569/47340
    public class LinkedList<T> : Node<T>, IDataEnumerableLinkedList<T>
    {
        private volatile int _count = 0;

        public LinkedList() : base() { }

        public LinkedList(T data) : base(data) { Interlocked.Increment(ref _count); }

        public LinkedList(INode<T> head) :  base(head.Data, head.Next) { Interlocked.Increment(ref _count); }
        
        public int Count { get { return _count; } }

        public void Add(T data)
        {
            Append(data);
        }

        public INode<T> Append(T data)
        {
            return Append(new Node<T>(data));
        }

        public INode<T> Append(INode<T> node)
        {
            // If the list is empty
            // copy a reference of the data from the 
            // node argument to the head node of the list

            // Otherwise, create a new node
            // Find the last node in the present list
            // Set the Next of the last node to the
            // newly created node
            throw new NotImplementedException();
        }

        public INode<T> InsertAt(T data, int index)
        {
            return InsertAt(new Node<T>(data), index);
        }

        public INode<T> InsertAt(INode<T> node, int index)
        {
            // if position < count or position > count, throw out of range

            // if the list is empty and the position
            // is 0:
            // Copy the data reference to the head node

            // Otherwise, if the list is not empty

            // BEGINNING
            // If index == 0
            // Set the Next of the new node
            // to the Next of the present head of the list

            // Traverse the list to find the nodes
            // at indices (index - 1) and (index)

            // END
            // If there isn't any node at (index), then
            // this is really just an Append call, so
            // set the newly created node as the last node, 
            // i.e., set the Next of the (index - 1) node
            // to point to the newly created node

            // MIDDLE
            // Otherwise, if there *is* a node at (index), 
            // then set the Next of (index - 1) to the
            // newly created node
            // And set the Next of the newly created node
            // to the node at (index)

            throw new NotImplementedException();
        }

        public INode<T> RemoveAt(int index)
        {
            // if index is negative or greater than count
            // throw out of range

            // if the list is empty, return null;

            // Traverse to (index - 1) and (index + 1)
            // set Next of (index - 1) to (index + 1)
            // return index node
            throw new NotImplementedException();
        }

        public INode<T> RemoveFirst()
        {
            // if the list is empty return null;

            // 
            throw new NotImplementedException();
        }

        public INode<T> RemoveFirst(T data)
        {
            throw new NotImplementedException();
        }

        public INode<T> RemoveLast()
        {
            throw new NotImplementedException();
        }

        public INode<T> RemoveLast(T data)
        {
            throw new NotImplementedException();
        }

        public INode<T> RemoveAll(T data)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Print(TextWriter w = null)
        {
            this.Print<T>(w);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}