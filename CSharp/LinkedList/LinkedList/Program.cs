using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<int> { 1, 2, 3, 4, 5 };

            list.Add(6);
            list.Print();

            list.InsertAt(0, 0);
            list.Print();

            list.Add(4);
            list.Print();

            list.RemoveAll(4);
            list.Print();

            list.InsertAt(4, 4);
            list.Print();

            list.Append(7);
            list.Print();

            list.RemoveFirst();
            list.Print();

            list.RemoveLast();
            list.Print();

            Console.ReadKey();
        }
    }
}