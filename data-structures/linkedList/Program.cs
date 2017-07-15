using System;

namespace linkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> myList = new LinkedList<string>();

            myList.PushBack("Hello");
            myList.PushBack("World");
            myList.PushFront("Heyooo");

            myList.Insert(0, "Last");

            Console.WriteLine(myList.ValueAt(0));
            Console.WriteLine(myList.ValueAt(1));
            Console.WriteLine(myList.ValueAt(2));
            Console.WriteLine(myList.ValueAt(3));

            myList.Reverse();
            Console.WriteLine("------reverse------");
            Console.WriteLine(myList.ValueAt(0));
            Console.WriteLine(myList.ValueAt(1));
            Console.WriteLine(myList.ValueAt(2));
            Console.WriteLine(myList.ValueAt(3));

            Console.ReadLine();
        }
    }
}
