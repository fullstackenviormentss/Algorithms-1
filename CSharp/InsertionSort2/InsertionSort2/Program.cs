using System;

namespace InsertionSort2
{
    class Program
    {
        static void Main(string[] args)
        {
            UI.PrintGreeting();

            var source = UI.GetInputArrayFromUser();

            if (source == null) return;

            source.Print(leadingMessage: "Source: ");
            Sorter.InsertionSort(source);
            source.Print(leadingMessage: "Sorted: ");

            Console.ReadKey();
        }
    }
}
