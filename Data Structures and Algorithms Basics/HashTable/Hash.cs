using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
	public class HashTable<T>
	{
		ListNode<T>[] tableData;
		public int capacity;
		public int size;

		
		public HashTable(int capacity)
		{
			this.capacity = capacity;
			tableData = new ListNode<T>[capacity];
			for (int i = 0; i < tableData.Length; i++)
			{
				tableData[i] = null;
			}
			size = 0;
		}

		public int HashValue(int index)
		{
			return index % capacity;
		}

		
		public void Insert(int key, int value)
		{
			if (key != 0)
			{
				size++;
				int index = HashValue(key);
				while (tableData[index] != null && tableData[index].Key != key)
				{
					index = (index + 1) % capacity;
				}
				tableData[index] = new ListNode<T>(key, value);
			}
			Console.WriteLine("Node Inserted");
		}

		//method to delete a data
		public void Delete(int key)
		{
			int index = HashValue(key);

			ListNode<T> head = tableData[index];
			while (head != null)
			{
				if (head.Key== key)
				{
					size--;
					this.tableData[index] = null;
				}
				head = head.Reference;
			}

			Console.WriteLine("Node Deleted succesfully");
		}

		//method to return size of HashTable
		public int SizeHash()
		{
			return size;
		}

		//method to check a element is present in HashTable or not
		public bool ContainsValue(int val)
		{
			for (int i = 0; i < tableData.Length; i++)
			{
				if (tableData[i] == null)
				{
					i++;
				}
				else
				{
					if (tableData[i].Value == val)
						return true;
				}
			}
			return false;
		}

		//return value based on key
		public int GetValueByKey(int key)
		{
			if (tableData[key] == null)
			{
				return -1;
			}
			else
			{
				int val = tableData[key].Value;
				return val;

			}
		}

		//method to print hashtable	
		public void Print()
		{
			for (int i = 0; i < tableData.Length; i++)
			{
				ListNode<T> list = tableData[i];
				while (list != null)
				{
				    Console.WriteLine("Key = " + list.Key + " Value = " + list.Value);
					list = list.Reference;
				}
			}
		}

		public void Iterator()
		{
			if (tableData.Length == 0)
			{
				Console.WriteLine("Hashtable is empty");
				return;
			}
			while (!(tableData.Length == 0))
			{
				int key = int.Parse(Console.ReadLine());
				int index = HashValue(key);

				ListNode<T> head = tableData[index];
				while (head != null)
				{
					if (head.Key == key)
					{
						size--;
						this.tableData[index] = null;
					}
					head = head.Reference;
				}

			}


		}
	}


}

