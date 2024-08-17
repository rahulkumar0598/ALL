using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();
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
                    Console.WriteLine("6 Centerreverse");
                    Console.WriteLine("7 sort");
                    Console.WriteLine("8 reverse");
                    Console.WriteLine("9 Iterator");
                    Console.WriteLine("10 Print");
                    Console.WriteLine("11 close program");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("enter value");
                            int value = int.Parse(Console.ReadLine());                           
                            queue.Enqueue( value);
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
                            queue.Center();
                            break;
                        case 7:
                            queue.Sort();
                            break;
                        case 8:
                            queue.Reverse();
                            break;
                        case 9:
                            queue.Iterator();
                            break;
                        case 10:
                            queue.Print();
                            break;
                        case 11:
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
