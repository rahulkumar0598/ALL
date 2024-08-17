using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Priority_Queue_Work
{
	public class Node
	{
		public int data;
		public int priority;
		public Node reference;

		public Node()
		{
			priority = -1;
			reference = null;

		}		
	}
}
