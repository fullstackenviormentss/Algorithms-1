using System.Collections.Generic;

namespace LinkedList
{
    public interface IDataEnumerableLinkedList<T> : ILinkedList<T>, IEnumerable<T>
    {
        // This is ideal and can infact be renamed simply as IEnumerableLinkedList<T>
        // Because having a list of enumerable nodes is an implementation detail that users
        // don't and shouldn't care about.

        // To support the collection initializer syntax
        void Add(T data);
    }
}