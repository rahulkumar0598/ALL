using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_List
{
    public class Node
    {
        public int data { get; set; }
        public Node next { get; set; }
        public Node()
        {
            this.next = null;
        }


    }
}
