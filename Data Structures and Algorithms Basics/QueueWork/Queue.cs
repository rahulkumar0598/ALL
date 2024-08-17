using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueWork
{
    public class Queue
    {
        public int count { get; set; }
        public int[] queue;
        public Queue()
        {
            Console.WriteLine("Queue Size will Be");
            int size = int.Parse(Console.ReadLine());
            queue = new int[size];
            count = 0;

        }
        public void Enqueue(int value)
        {
            if (!(count == queue.Length))
            {
                queue[count = count + 1] = value;

            }
            else
            {
                Console.WriteLine("Queue is full ");
            }
        }
        public  int Dequeue()
        {
            if (!(count == 0))
            {
                
                int num = queue[0];
                for (int index = 0; index < count ; index++)
                {
                    queue[index] = queue[index + 1];
                }
                count--;
                return num;
            }
            else
            {
                throw new Exception("queue is empty");
            }
        }
        public int Peek()
        {
           
            return queue[count];
        }
        public void Print()
        {
            if (!(count == 0))
            {
                Console.WriteLine("queue data");
                for (int index = count; index > 0; index--)
                {
                    Console.WriteLine($"Value of stack number {index - 1} is {queue[index]}");
                }
            }
            else
            {
                Console.WriteLine("Queue is empty");
            }
        }
        public int Size()
        {
            int size = 0;
            if (!(count == 0))
            {
                Console.WriteLine("Queue size");
                for (int index = count; index > 0; index--)
                {
                    size = size + 1;
                }
                return size;
            }
            else
            {
                throw new Exception("Queue is empty");
            }
        }
        public void ContainsData(int data)
        {
            if (!(count == 0))
            {
                for (int index = count; index > 0; index--)
                {
                    if (data.Equals(queue[index]))
                    {
                        Console.WriteLine("data is present " + data);
                        break;
                    }

                }
            }
            else
            {
                Console.WriteLine("queue is empty");
            }
        }
        public void Reverse()
        {
            int[] temporaryQueue = new int[count + 1];
            int counter = count;
            for (int index = 0; index <= count; index++)
            {
                temporaryQueue[counter] = queue[index];
                counter--;
            }
            queue = temporaryQueue;
        }
        public void Iterator()
        {
            if (count == 0)
            {
                Console.WriteLine("queue is empty");
                return;
            }
            while (!(count == 0))
            {
                Console.WriteLine(Dequeue());
            }

        }
        public void Center()
        {
            if ((count == queue.Length))
            {
                Console.WriteLine("stack is empty");
            }
            else if (count % 2 == 0)//even
            {
                for (int index = 0; index < (count / 2) + 1; index++)
                {
                    int num = (count / 2);
                    if (num == index)
                    {
                        Console.WriteLine("\n Center" + queue[index]);
                    }
                }

            }
            else//odd
            {
                for (int index = 0; index <= (count / 2) + 1; index++)
                {
                    int num = (count / 2) + 1;

                    if (num == index)
                    {
                        Console.WriteLine("\n Center" + queue[index]);
                    }
                }
            }

        }
        public void Sort()
        {
            if (count == 0)
            {
                Console.WriteLine("stack is empty");
            }
            else
            {

                for (int index = 0; index <= count; index++)
                {
                    int key = queue[index];
                    int index2 = index - 1;

                    while (index2 >= 0 && queue[index2] > key)
                    {
                        queue[index2 + 1] = queue[index2];
                        index2 = index2 - 1;
                    }
                    queue[index2 + 1] = key;
                }

            }
        }

    }
}
