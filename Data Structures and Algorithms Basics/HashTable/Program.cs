using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<int> hashTable = new HashTable<int>(20);
            try
            {
                int choice = -1;
                while (choice != 8)
                {
                    Console.WriteLine("Enter Your Choice");
                    Console.WriteLine("1 Insert");
                    Console.WriteLine("2 Delete");
                    Console.WriteLine("3 Contains");
                    Console.WriteLine("4 Get Value by key");
                    Console.WriteLine("5 size");
                    Console.WriteLine("6 Iterator");
                    Console.WriteLine("7 Print");
                    Console.WriteLine("8 close program");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter key");
                            int key = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter value");
                            int value = int.Parse(Console.ReadLine());
                            hashTable.Insert(key,value);
                            break;
                        case 2:
                            Console.WriteLine("Enter key");
                            int key1 = int.Parse(Console.ReadLine());
                            hashTable.Delete(key1);
                            break;                       
                        case 3:
                            int search = int.Parse(Console.ReadLine());
                            hashTable.ContainsValue(search);
                            break;
                        case 4:
                            Console.WriteLine("Enter key");
                            int key2 = int.Parse(Console.ReadLine());
                            hashTable.GetValueByKey(key2);
                            break;
                        case 5:
                            Console.WriteLine(hashTable.SizeHash());
                            break;
                        case 6:

                            hashTable.Iterator();
                            break;
                        case 7:
                            hashTable.Print();
                            break;
                        case 8:
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
