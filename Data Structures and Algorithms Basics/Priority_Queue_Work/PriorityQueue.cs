using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Priority_Queue_Work
{
	public class PriorityQueue<T>
	{
		public Node head;
		public int count;

		public PriorityQueue()
		{
			head = null;
			count = 0;
		}

		public void Enqueue(int p, int d)
		{
			Node newNode = new Node();
			newNode.data = d;
			newNode.priority = p;
			if (head == null || p < head.priority)
			{
				newNode.reference = head;
				head = newNode;
				count++;
				Console.WriteLine("Data inserted sucessfully!!");
			}
			else
			{
				Node temp = head;
				temp = head;
				while (temp.reference != null && (temp.reference).priority <= p)
				{
					temp = temp.reference;
				}
				newNode.reference = temp.reference;
				temp.reference = newNode;
				count++;
				Console.WriteLine("Data inserted sucessfully!!");
			}
		}

		public void Print()
		{
			Node temp = new Node();
			temp = head;
			if (!(head == null))
			{
				while (temp != null)
				{
					Console.WriteLine("Data = " + temp.data + " Priority =" + temp.priority);
					temp = temp.reference;
				}

			}
			else
			{
				Console.WriteLine("Queue is Empty");
			}
		}

		public void Dequeue()
		{
			if (!(head == null))
			{
				Console.WriteLine(head.data + " Data deleted successfully!!");
				head = head.reference;

			}
			else
			{
				Console.WriteLine("Queue is Empty");
			}
		}

		public int Size()
		{
			return count;
		}

		public void ContainsData(T data)
		{
			if (!(count == 0))
			{
				for (int index = count; index > 0; index--)
				{
					if (data.Equals(head.data))
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

		public void Iterator()
		{
			if (count == 0)
			{
				Console.WriteLine("queue is empty");
				return;
			}
			while (!(count == 0))
			{
				if (!(head == null))
				{
					Console.WriteLine("Iterating the data");
					Console.WriteLine(head.data +" "+head.priority);
					head = head.reference;

				}
			}


		}
		public void Reverse()
		{
			Node preNode = null;
			Node curNode = head;
			Node temporaryNode = null;
			while (curNode != null)
			{
				temporaryNode = curNode.reference;
				curNode.reference = preNode;
				preNode = curNode;
				curNode = temporaryNode;
			}
			head = preNode;

		}
		public int Peek()
		{
			if (head == null)
				return -1;
			else
				return head.data;
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
					temp = temp.reference;
				}
				Console.WriteLine("\nCenter = " + temp.data);

			}
			else if (Size() == 0)
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
					temp = temp.reference;
				}
				Console.WriteLine("\nCenter elements are = " + temp.data + " " + (temp.reference).data);
			}
		}


	}
}

    

