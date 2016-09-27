using System.Collections.Generic;

namespace LinkedList
{
    public interface INodeEnumerableLinkedList<T> : ILinkedList<T>, IEnumerable<INode<T>>
    {
        // This is not idead because a node is an implementation detail that users are never
        // interested in dealing with -- they don't want to add nodes in the collection initializer
        // syntax and they don't want to enumerate nodes and don't want to know about the Next pointers
        // and how the list is internally structures. To them, it's just data they can use.
        // They shouldn't be encumbered with implementation detail.
        // Still, I am keeping this interface and will implement it only as a mental exercise.
        
        // To support the collection initializer syntax
        void Add(INode<T> node);
    }
}
