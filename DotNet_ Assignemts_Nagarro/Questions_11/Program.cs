using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions_11
{
    public static class ExtentionMethod
    {
        public static bool IsOdd( this int number)
        {
            return (number % 2 == 0) ? false : true;
        }
        public static bool IsEven(this int number)
        {
            return (number % 2 != 0) ? false : true;
        }
        public static bool IsPrime(this int number)
        {
            for (int index = 2; index <= number / 2; index++)
            {
                if (number % index == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsDivisibleBy(this int number,int divisor)
        {
            return ((number % divisor) == 0) ? true : false;
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number");
            int number = int.Parse(Console.ReadLine());
           // var access = new ExtentionMethod();
            Console.WriteLine($"Number is Odd {number.IsOdd()}");
            Console.WriteLine($"Number is Even {number.IsEven()}");
            Console.WriteLine($"Number is Prime {number.IsPrime()}");
            Console.WriteLine($"Number is divisible by {number.IsDivisibleBy(3)}");
            Console.ReadLine();
        }
    }
}
