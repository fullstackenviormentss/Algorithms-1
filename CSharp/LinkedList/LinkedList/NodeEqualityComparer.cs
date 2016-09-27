using System.Collections.Generic;

namespace LinkedList
{
    internal class NodeEqualityComparer<T> : IEqualityComparer<Node<T>>
    {
        public bool Equals(Node<T> x, Node<T> y)
        {
            return object.Equals(x, y) && x.Data.Equals(y.Data);
        }

        public int GetHashCode(Node<T> obj)
        {
            return obj.GetHashCode();
        }
    }
}
