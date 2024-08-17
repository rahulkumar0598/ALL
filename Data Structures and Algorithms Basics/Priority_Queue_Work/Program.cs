using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Priority_Queue_Work
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();
            try
            {
                int choice = -1;
                while (choice != 10)
                {
                    Console.WriteLine("Enter Your Choice");
                    Console.WriteLine("1 Enqueue");
                    Console.WriteLine("2 Dequeue");
                    Console.WriteLine("3 Peek");
                    Console.WriteLine("4 ContainData");
                    Console.WriteLine("5 size");
                    Console.WriteLine("6 reverse");
                    Console.WriteLine("7 Center");
                    Console.WriteLine("8 Iterator");
                    Console.WriteLine("9 Print");
                    Console.WriteLine("10 close program");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("enter value");
                            int value = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter priority");
                            int priority = int.Parse(Console.ReadLine());
                            queue.Enqueue(priority,value);
                            break;
                        case 2:
                            queue.Dequeue();
                            break;
                        case 3:
                            Console.WriteLine(queue.Peek());
                            break;
                        case 4:
                            int search = int.Parse(Console.ReadLine());
                            queue.ContainsData(search);
                            break;
                        case 5:
                            queue.Size();
                            break;
                        case 6:
                            queue.Reverse();
                            break;
                        case 7:
                            queue.Center();
                            break;
                        case 8:
                            queue.Iterator();
                            break;
                        case 9:
                            queue.Print();
                            break;
                        case 10:
                            break;
                        default:
                            Console.WriteLine("out of range value enter");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}