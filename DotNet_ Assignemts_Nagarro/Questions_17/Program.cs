using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions_17
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {

        }
    }

   
    class Program
    {
        public static bool Validation(int value)
        {
            switch (value)
            {
                case 1:
                    Console.WriteLine("Enter the even number");
                    int number1 = int.Parse(Console.ReadLine());
                    if (number1 % 2 != 0)
                    {
                        throw new CustomException("the number is not even");
                    }
                    return true;
                    
                case 2:
                    Console.WriteLine("Enter the odd number");
                    int number2 = int.Parse(Console.ReadLine());
                    if (number2 % 2 == 0)
                    {
                        throw new CustomException("the number is not odd");
                    }
                    return true;
                case 3:
                    Console.WriteLine("Enter the prime number ");
                    int number3 = int.Parse(Console.ReadLine());
                    if (number3 == 1)
                    {
                        throw new CustomException("the number is not prime");

                    }
                    if (number3 == 2)
                    {
                        return true;
                    }
                    var limit = Math.Ceiling(Math.Sqrt(number3));
                    for (int index = 2; index <= limit; index++)
                    {
                        if (number3 % index == 0)
                        {
                            throw new CustomException("the number is not prime");
                        }
                    }
                    return true;
                case 4:
                    Console.WriteLine("Enter a negative number ");
                    int number4 = int.Parse(Console.ReadLine());
                    if (number4 >= 0)
                    {
                        throw new CustomException("entered number is not negative");
                    }
                    return true;
                case 5:
                    Console.WriteLine("Enter zero ");
                    int number5 = int.Parse(Console.ReadLine());
                    if (number5 != 0)
                    {
                        throw new CustomException("entered number is not zero");

                    }
                    return true;
                default:
                   throw new CustomException("The number is out in the range 1-5");
            }

        }

        static void Main(string[] args)
        {
            int count = 5;
           
            while (count >= 0)
            {

                if (count == 0)
                {
                    throw new CustomException("limit exceed ! " +
                   "You have played this game 5 times");

                }
                Console.WriteLine("Enter the number 1 to 5");
                int value = int.Parse(Console.ReadLine());
                try
                {
                    Validation(value);
                }
                catch(Exception e)
                {

                    Console.WriteLine("something bad happened"+e.Message);
                }
                count--;
            }
            Console.ReadLine();
        }
    }
}
