using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions_7
{
    public class Duck
    {
        public string name { get; set; }
        double weight;
        public double Weight { get { return weight; } set { value = weight; } }
        int noOfWings;
        public int NoOfWings { get { return noOfWings; } set { value = noOfWings; } }
        public Duck()
        {

        }
        public Duck(string name,double weight,int noOfWings)
        {
            this.name = name;
            this.weight = weight;
            this.noOfWings = noOfWings;
        }

        public void showDetails()
        {
            Console.WriteLine($"Name :\t {name} \n Weight : \t{weight}\n No. Of Wings :\t {noOfWings} \n ");
        }
    }

    class Program
    {
      
  
        static void Main(string[] args)
        {

            List<Duck> ducklist = new List<Duck>();
            // Add a duck
            Duck duck1 = new Duck("Rubber",2,6);
            ducklist.Add(duck1);
            Duck duck2 = new Duck("Mallard", 2, 8);
            ducklist.Add(duck2);
            Duck duck3 = new Duck("Rubber", 3, 4);
            ducklist.Add(duck3);
            Duck duck4 = new Duck("ReadHead", 2, 9);
            ducklist.Add(duck4);
            foreach(var duck in ducklist)
            {
                duck.showDetails();
            }
            Console.WriteLine();


            //  Remove a duck
            ducklist.Remove(duck4);
            Console.WriteLine("after removing");
            Console.WriteLine();

            foreach (var duck in ducklist)
            {
                duck.showDetails();
            }
            Console.WriteLine();

            //  Capability to iterate the duck collection in increasing order of their weights.
            var orderWeight = from duck in ducklist
                              orderby duck.Weight
                              select duck;
            Console.WriteLine("Duck List Increasing order of wings : ");
            Console.WriteLine();
            foreach(var duck in orderWeight)
            {
                duck.showDetails();
            }
            //Capability to iterate the duck collection in increasing order of number of wings.
            var orderWing = from duck in ducklist
                              orderby duck.NoOfWings
                              select duck;
            Console.WriteLine("Duck List Increasing order of wings : ");
            Console.WriteLine();

            foreach (var duck in orderWing)
            {
                duck.showDetails();
            }
            Console.ReadLine();

        }
    }
}
