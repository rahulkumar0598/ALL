using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_1__3_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter true or false");
            string input1 = Console.ReadLine();
            bool boolValue = Convert.ToBoolean(input1);
            Console.WriteLine(boolValue);

            Console.ReadLine();
        }
    }
}
