using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_List
{
    public class LinkedList
    {
        public Node head { get; set; }
        public LinkedList()
        {
            this.head = null;
        }
        public void Insert(int data)
        {
            Node node = new Node();
            node.data = data;
            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                Node n = this.head;
                while (n.next != null)
                {
                    n = n.next;
                }
                n.next = node;
            }
        }
        private Node GetNodeByPosition(int position)
        {
            if (position < 0)
            {
                throw new IndexOutOfRangeException("enter value is out of range" + position);
            }
            Node currentNode = head;
            try
            {
                for (int i = 0; i < position; i++)
                {
                    currentNode = currentNode.next;

                }
            }

            catch (Exception e)
            {
                throw new IndexOutOfRangeException("out of range" + position + e.Message);

            }
            return currentNode;

        }
        public int Size()
        {
            Node n = head;
            int count = 0;
            while (n != null)
            {
                n = n.next;
                count = count + 1;
            }
            return count;
        }
        public void Center()
        {
            // for odd
            if (Size() % 2 != 0)
            {
                Node temp = new Node();
                temp = head;
                for (int index = 0; index < Size() / 2; index++)
                {
                    temp = temp.next;
                }
                Console.WriteLine("\nCenter = " + temp.data);

            }
            else if (Size()== 0)
            {    
                Console.WriteLine("This list is empty");
            }
            else
            {   
                // for even
                Node temp = new Node();
                temp = head;
                for (int i = 0; i < Size() / 2 - 1; i++)
                {
                    temp = temp.next;
                }
                 Console.WriteLine("\nCenter elements are = " + temp.data );
            }
        }
        public void Sort()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                Node temp1;
                Node temp2 = null;
                int temp;
                temp1 = head;
                while (temp1 != null)
                {
                    temp2 = temp1.next;
                    while (temp2 != null)
                    {
                        if (temp1.data > temp2.data)
                        {
                            temp = temp1.data;
                            temp1.data = temp2.data;
                            temp2.data = temp;
                        }

                        temp2 = temp2.next;
                    }
                    temp1 = temp1.next;
                }
            }

        }

            public void InsertAtPosition(int data, int position)
        {
            Node node = new Node();
            node.data = data;
            node.next = null;
            if (position == 0)
            {
                node.next = head;
                head = node;

            }
            else if (position == Size())
            {
                Insert(data);
            }
            else
            {
                Node previousNode = GetNodeByPosition(position - 1);
                Node nexNode = GetNodeByPosition(position);
                previousNode.next = node;
                node.next = nexNode;
            }

        }
        public void Delete(int data)
        {
            if (this.head.data.Equals(data))
            {
                head = head.next;
                return;
            }
            Node temporaryNode = head;
            while (temporaryNode.next != null)
            {
                if (temporaryNode.next.data.Equals(data))
                {
                    break;
                }
                temporaryNode = temporaryNode.next;
            }
            if (temporaryNode.next == null)
            {
                Console.WriteLine($"given element is not found {data}");
            }
            else
            {
                temporaryNode.next = temporaryNode.next.next;
            }

        }
        public void DeleteAtPosition(int position)
        {
            if (position < 0)
            {
                throw new IndexOutOfRangeException("out of range");
            }
            if (position > this.Size())
            {
                position = Size() - 1;
            }
            if (this.head == null)
            {
                Console.WriteLine("no linked list is added");
            }
            Node temporaryNode = this.head;
            object result = null;
            if (position == 0)
            {
                result = temporaryNode.data;
                this.head = temporaryNode.next;

            }
            else
            {
                for (int i = 0; i < position; i++)
                {
                    temporaryNode = temporaryNode.next;
                }
                result = temporaryNode.next.data;
                temporaryNode.next = temporaryNode.next.next;
            }

            Console.WriteLine($"delete at postion \n{result}");

        }
        public void Reverse()
        {
            Node prevNode = null;
            Node curNode = head;
            Node tempNode = null;
            while (curNode != null)
            {
                tempNode = curNode.next;
                curNode.next = prevNode;
                prevNode = curNode;
                curNode = tempNode;
            }
            head = prevNode;

        }    
        public void Iterator()
        {
            Console.WriteLine("\nIterator\n");
            Node currenthNode=head;
            while (currenthNode != null)
            {
                int data = currenthNode.data;
                currenthNode = currenthNode.next;
                Console.WriteLine(data);
            }
            
        }
        

        
        public void Print()
        {
            Node temporaryNode = this.head;
            if (head == null)
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                while (temporaryNode != null)
                {
                    Console.WriteLine(temporaryNode.data);
                    temporaryNode = temporaryNode.next;
                }
            }

        }
    }
}
