using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions_12
{
    
    class Program
    {
        public static void PrintMessage(string message, IEnumerable<int> List)
        {
            Console.WriteLine(message + " : ");
            foreach(int num in List)
            {
                Console.WriteLine(num + " ");
            }
        }
        public static bool GreaterThan(int number)
        {
            return number > 5;
        }
        public static bool LesserThan(int number)
        {
            return number < 5;
        }
        public static bool AnyThingMethod(int number)
        {
            return number != 5;
        }

        static void Main(string[] args)
        {
            var list = new List<int>();
            Console.WriteLine("Enter the size of List: ");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine($"Enter {size} numbers");
            for (int index = 0; index < size; index++)
            {
                int number = int.Parse(Console.ReadLine());
                list.Add(number);
            }
            // Find odd - Lambda Expression - without curly brackets
            var odd = list.Where(index => index % 2 == 1);
            PrintMessage("odd Number",odd);
            // Find Even - Lambda Expression - with curly brackets
            var even = list.Where(index => { return index % 2 == 0; });
            PrintMessage("Even Number", even);
            // Find Prime - Anonymous Method
            var prime = list.Where(delegate (int number)
            {
                if (number <= 1)
                {
                    return false;
                }
                for (int index = 2; index <= number/2; index++)
                {
                    if (number % index == 0)
                    {
                        return false;
                    }
                }
                return true;
            });
            PrintMessage("PrimeNumber = ", prime);
            //Find Prime Another - Lambda Expression
            var primeAnother = list.Where(number =>
              {
                  if (number <= 1)
                  {
                      return false;
                  }
                  for (int index = 2; index <= number / 2; index++)
                  {
                      if (number % index == 0)
                      {
                          return false;
                      }
                  }
                  return true;
              });
            PrintMessage("anotherPrimeNumber =", primeAnother);
            //Find Elements Greater Than Five - Method Group Conversion Syntax
            Func<int, bool> condition = GreaterThan;
            var greater = list.Where(condition);
            PrintMessage("greater than five", greater);
            // Find Less than Five - Delegate Object in Where - Method Group Conversion Syntax in Constructor of Object
            Func<int,bool> ConditionLess = new Func<int,bool>(LesserThan);
            var lessThan = list.Where(ConditionLess);
            PrintMessage("lessThan Five", lessThan);
            //Find 3k - Delegate Object in Where -Lambda Expression in Constructor  of Object
            Func<int, bool> condition3k = new Func<int, bool>(x => x % 3 == 0);
            IEnumerable<int> list3k = list.Where(condition3k);
            PrintMessage("3k =", list3k);
            //Find 3k + 1 - Delegate Object in Where -Anonymous Method in Constructor of Object
            Func<int,bool> condition3kplus1=new Func<int, bool>(delegate (int number)
            {
                return number % 3 == 1;
            });
            IEnumerable<int> list3kplus1 = list.Where(condition3kplus1);
            PrintMessage("3k+1", list3kplus1);
            // Find 3k + 2 - Delegate Object in Where -Lambda Expression Assignment
            Func<int, bool> condition3kplus2 = number => number % 3 == 2;
            IEnumerable<int> list3kplus2 = list.Where(condition3kplus2);
            PrintMessage("3k+2", list3kplus2);
            //Find anything - Delegate Object in Where - Anonymous Method Assignment
            Func<int, bool> Anything = delegate (int number)
               {
                   return number != 0;
               };
            IEnumerable<int> anything = list.Where(Anything);
            PrintMessage("anything", anything);
            // Find anything - Delegate Object in Where - Method Group Conversion
            Func<int, bool> AnythingAnother = AnyThingMethod;
            IEnumerable<int> anythingAnother = list.Where(AnythingAnother);
            PrintMessage("Any Thing Another", anythingAnother);
            Console.ReadLine();



        }

    }

}
