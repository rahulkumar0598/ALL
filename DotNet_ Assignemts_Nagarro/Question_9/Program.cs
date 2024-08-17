using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions_9
{
    class Program
    {
        public class Node
        {
            public int data;

            public int priority;

            public Node next;
        }

        public static Node node = new Node();
        public static Node newNode(int d, int p)
        {
            Node temp = new Node();
            temp.data = d;
            temp.priority = p;
            temp.next = null;

            return temp;
        }
        public static int peek(Node head)
        {
            return head.data;
        }
        public static Node pop(Node head)
        {
            Node temp = head;
            head = head.next;
            return head;
        }
        public static Node push(Node head,
                                int d, int p)
        {
            Node start = head;

            Node temp = newNode(d, p);

            if (head.priority > p)
            {

                temp.next = head;
                head = temp;
            }
            else
            {
                while (start.next != null &&
                    start.next.priority < p)
                {
                    start = start.next;
                }

                temp.next = start.next;
                start.next = temp;
            }
            return head;
        }


        public static int isEmpty(Node head)
        {
            return ((head) == null) ? 1 : 0;
        }

        static void Main(string[] args)
        {
            Node pq = newNode(4, 1);
            pq = push(pq, 5, 2);
            pq = push(pq, 6, 3);
            pq = push(pq, 7, 0);

            while (isEmpty(pq) == 0)
            {
                Console.Write("{0:D} ", peek(pq));
                pq = pop(pq);
            }
            Console.ReadLine();
        }
    }
}
