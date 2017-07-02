using System;

namespace vector
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector<int> intVector = new Vector<int>();

            TestPush();

            Console.ReadKey();
        }

        private static void TestPush()
        {
            Vector<int> intVector = new Vector<int>();

            intVector.Push(8);
            intVector.Push(123123);
            intVector.Push(4);
            intVector.Push(6);

            intVector.Insert(1, 777);

            System.Console.WriteLine("At 0: " + intVector.At(0));
            System.Console.WriteLine("At 0: " + intVector.At(1));
            System.Console.WriteLine("At 0: " + intVector.At(2));
            System.Console.WriteLine("At 0: " + intVector.At(3));
            System.Console.WriteLine("At 0: " + intVector.At(4));

            System.Console.WriteLine("Capacity: " + intVector.Capacity);
            System.Console.WriteLine("Size: " + intVector.Size);
        }
    }
}
