using System;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            UI.PrintGreeting();

            var source = UI.GetInputArrayFromUser();

            if (source == null) return;

            source.Print(leadingMessage: "Source: ");
            Sorter.SelectionSort(source);
            source.Print(leadingMessage: "Sorted: ");

            Console.ReadKey();
        }
    }
}
