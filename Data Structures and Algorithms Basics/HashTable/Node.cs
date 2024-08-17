using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
	public class ListNode<T>
	{
		int key;
		int value;
		ListNode<T> reference;

		public ListNode() 
		{

		}
		public ListNode(int Key, int value)
		{
			this.key = Key;
			this.value = value;
			this.reference = null;
		}

		public int Key
		{
            get
            {
				return this.key;

			}
			set
            {
				this.Key = key;
			}
		}

		public int Value
		{
            get
			{
				return value;
			}
            set
            {
				this.value = value;

			}
		}
		public ListNode<T> Reference
		{
			get
			{
				return reference;
			}
            set
            {
				this.reference = value;

			}
		}

		

	}
}
