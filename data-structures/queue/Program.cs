using System;

namespace queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(-1);
            queue.Enqueue(1000);

            System.Console.WriteLine(queue.Dequeue());
            System.Console.WriteLine(queue.Dequeue());
            System.Console.WriteLine(queue.Dequeue());
            System.Console.WriteLine(queue.Dequeue());
            System.Console.WriteLine(queue.Dequeue());
        }
    }
}
