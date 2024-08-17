using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_3
{
   
    
    class Program

    {
        static void PrimeNumber(int input3,int input4)
        {
            bool prime = true;
            for (int index1=input3; index1<=input4; index1++)
            {
                for (int index2=2;index2<input4;index2++)
                {
                    if (index1!=index2 && index1%index2==0)
                    {
                        prime = false;
                        break;
                    }
                }
                if (prime)
                {
                    Console.WriteLine( index1);
                }
                prime = true;
            }
            
        }
        static void Main(string[] args)
        {
            backLine:
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();
            int input3 = int.Parse(input1);
            int input4 = int.Parse(input2);
            if (input3>=2 &&input4<=1000)
            {   if (input3 < input4)
                {   
                    PrimeNumber(input3, input4);
                    
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    goto backLine;
                }
            }
            else
            {
                Console.WriteLine("Enter correct input");
                goto backLine;
            }
            Console.ReadLine();

        }
    }
}
