using System.Collections.Generic;

namespace LinkedList
{
    internal class NodeDataEqualityComparer<T> : IEqualityComparer<Node<T>>
    {
        public bool Equals(Node<T> x, Node<T> y)
        {
            // TO DO:
            return x.Data.Equals(y.Data);
        }

        public int GetHashCode(Node<T> obj)
        {
            // TO DO:
            return obj.GetHashCode();
        }
    }
}
