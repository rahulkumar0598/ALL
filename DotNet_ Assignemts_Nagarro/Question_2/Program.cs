using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();//734
            string input2 = Console.ReadLine();//734.0
            int input3 = int.Parse(Console.ReadLine());
            float input4 = float.Parse(Console.ReadLine());
            object book = "Math";
            char[] bookInArray = { 'M', 'a', 't', 'h' };
            object input5 = new string(bookInArray);
            Console.WriteLine("comaparison of two string");
            Console.WriteLine(input1 == input2);
            Console.WriteLine(input1.Equals(input2));
            Console.WriteLine(ReferenceEquals(input1, input2));
            Console.WriteLine("comparson of two numbers");
            Console.WriteLine(input3 == input4);
            Console.WriteLine(input3.Equals(input4));
            Console.WriteLine(ReferenceEquals(input3, input4));
            Console.WriteLine("comparison on the basis of object");
            Console.WriteLine(book == input5);
            Console.WriteLine(book.Equals(input5));
            Console.WriteLine(ReferenceEquals(book, input5));
            Console.ReadLine();

        }
    }
}
