using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();
            try
            {
                int choice = -1;
                while (choice != 11)
                {
                    Console.WriteLine("Enter Your Choice");
                    Console.WriteLine("1 • Insert");
                    Console.WriteLine("2 • Insert at position");
                    Console.WriteLine("3 Delete");
                    Console.WriteLine("4 Delete at position");
                    Console.WriteLine("5 Center");
                    Console.WriteLine("6 Sort");
                    Console.WriteLine("7 Reverse");
                    Console.WriteLine("8 Size");
                    Console.WriteLine("9 Iterator");
                    Console.WriteLine("10 Print");
                    Console.WriteLine("11 close program");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            int value = int.Parse(Console.ReadLine());
                            linkedList.Insert(value);
                            break;
                        case 2:
                            int data = int.Parse(Console.ReadLine());
                            int position = int.Parse(Console.ReadLine());

                            linkedList.InsertAtPosition(data, position);
                            break;
                        case 3:
                            int value1 = int.Parse(Console.ReadLine());

                            linkedList.Delete(value1);
                            break;
                        case 4:
                            int search = int.Parse(Console.ReadLine());
                            linkedList.DeleteAtPosition(search);
                            break;
                        case 5:
                            linkedList.Center();
                            break;
                        case 6:
                            linkedList.Sort();
                            break;
                        case 7:
                            linkedList.Reverse();
                            break;
                        case 8:
                            linkedList.Size();
                            break;
                        case 9:
                            linkedList.Iterator();
                            break;
                        case 10:
                            linkedList.Print();
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
