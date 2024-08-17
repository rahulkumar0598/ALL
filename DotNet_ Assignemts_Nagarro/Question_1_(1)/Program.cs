using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_1__1_
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            int num = 0;
            int input4 = int.Parse(Console.ReadLine());
            Console.WriteLine("input4 " + input4);
            bool converted = Int32.TryParse(input1, out num);
            Console.WriteLine(converted + " " + num);
            if (converted == true)
            {
                int input2 = int.Parse(input1);
                int input3 = Convert.ToInt32(input1);
                Console.WriteLine(input2 / input3);
            }
            Console.ReadLine();
        }
    }
}
