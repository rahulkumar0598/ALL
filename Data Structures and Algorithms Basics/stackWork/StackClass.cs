using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stackCode
{
   
    public class Stack
    {
        public int count { get; set; }
        public int[] stack;
        public Stack()
        {
            count = 0;
            Console.WriteLine("size of stack");
            int size = int.Parse(Console.ReadLine());
            stack = new int[size];
        }
        public void Push(int pushTheValue)
        {
            if (!(count == stack.Length))
            {
                stack[count = count + 1] = pushTheValue;

            }
            else
            {
                throw new Exception("Stack is full");
            }
        }
        public int Pop()
        {
            if (!(count == 0))
            {
                return stack[count = count - 1] ;
            }
            else
            {
                throw new Exception("stack is empty");
            }
        }
        public int Peek()
        {
            return stack[count];
        }
        public void Print()
        {
            if (!(count == 0))
            {
                Console.WriteLine("stack data");
                for (int index = count ; index > 0; index--)
                {
                    Console.WriteLine($"Value of stack number {index-1} is {stack[index]}");
                }
            }
            else
            {
                Console.WriteLine("Stack is empty");
            }
        }
        public void Size()
        {
            int size = 0;
            if (!(count == 0))
            {
                Console.WriteLine("stack size");
                for (int index = count; index > 0; index--)
                {
                    size = size + 1;
                }
                Console.WriteLine(size);
            }
            else
            {
                Console.WriteLine("Stack is empty");
            }
        }
        public void ContainsData(int data)
        {
            if (!(count == 0))
            {
                for (int index = count; index > 0; index--)
                {
                    if (data.Equals(stack[index]))
                    {
                        Console.WriteLine("data is present "+data);
                        break;
                    }
                
                }
            }
            else
            {
                Console.WriteLine("stack is empty");
            }
        }
        public void Reverse()
        {
            int[] temporaryStack = new int[count + 1];
            int counter = count;
            for (int index = 0; index <=count; index++)
            {
                temporaryStack[counter] =stack[index];
                counter--;
            }
            stack = temporaryStack;
        }
        public void Iterator()
        {
            if (count == 0)
            {
                Console.WriteLine("stack is empty");
                return;
            }
            while (!(count == 0))
            {
                Console.WriteLine(Pop());
            }

        }
        public void Center()
        {
            if ((count == stack.Length))
            {
                Console.WriteLine("stack is empty");
            }
            else if (count % 2 == 0)//even
            {
                for (int index = 0; index < (count / 2)+1; index++)
                {
                    int num =(count/2);
                    if (num == index)
                    {
                        Console.WriteLine("\n Center" + stack[index]);
                    }
                }
           
            }
            else//odd
            {
                for (int index = 0; index <= (count / 2)+1; index++)
                {
                    int num = (count / 2)+1;

                    if (num == index)
                    {
                        Console.WriteLine("\n Center"+stack[index]);
                    }
                }
            }

        }
        public void Sort()
        {
            if (count==0)
            {
                Console.WriteLine("stack is empty");
            }
            else
            {

                for (int index = 0; index <= count; index++)
                {
                    int key = stack[index];
                    int index2 = index - 1;

                    while (index2 >= 0 && stack[index2] > key)
                    {
                        stack[index2 + 1] = stack[index2];
                        index2 = index2 - 1;
                    }
                    stack[index2 + 1] = key;
                }

            }
        }



    }

}


