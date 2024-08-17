using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stackCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            try
            {


                int choice = -1;
                while (choice != 11)
                {
                    Console.WriteLine("Enter Your Choice");
                    Console.WriteLine("1 Push");
                    Console.WriteLine("2 Pop");
                    Console.WriteLine("3 Peek");
                    Console.WriteLine("4 ContainData");
                    Console.WriteLine("5 size");
                    Console.WriteLine("6 Center");
                    Console.WriteLine("7 sort ");
                    Console.WriteLine("8 reverse");
                    Console.WriteLine("9 Iterator");
                    Console.WriteLine("10 Print");
                    Console.WriteLine("11 close program");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            int value = int.Parse(Console.ReadLine());
                            stack.Push(value);
                            break;
                        case 2:
                            stack.Pop();
                            break;
                        case 3:
                            Console.WriteLine(stack.Peek());
                            break;
                        case 4:
                            int search = int.Parse(Console.ReadLine());
                            stack.ContainsData(search);
                            break;
                        case 5:
                            stack.Size();
                            break;
                        case 6:
                            stack.Center();
                            break;
                        case 7:
                            stack.Sort();
                            break;
                        case 8:
                            stack.Reverse();
                            break;
                        case 9:
                            stack.Iterator();
                            break;
                        case 10:
                            stack.Print();
                            break;
                        case 11:
                            break;
                        default:
                            Console.WriteLine("out of range value enter");
                            break;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            
            Console.ReadLine();
        }
    }
}
