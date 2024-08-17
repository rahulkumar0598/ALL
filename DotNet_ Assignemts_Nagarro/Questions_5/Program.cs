using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions_5
{
    enum TypeOfDuck
    {
        Rubber, Mallard, Redhead
    }
    class Program
    { 
        class Duck
        {
            double weight;
            int numberOfWings;
            TypeOfDuck duckType;
            public Duck()
            {

            }
            public Duck(double weight,int numberOfWings,TypeOfDuck duckType)
            {
                this.weight = weight;
                this.numberOfWings = numberOfWings;
                this.duckType = duckType;

            }
            public virtual void showDetails()
            {
                if (duckType == TypeOfDuck.Mallard)
                {
                    Console.WriteLine("Mallard Duck");
                }
                if (duckType == TypeOfDuck.Rubber)
                {
                    Console.WriteLine("Rubber Duck");
                }
                if (duckType == TypeOfDuck.Redhead)
                {
                    Console.WriteLine("Redhead Duck");
                }
                Console.WriteLine($"Weight: {weight}");
                Console.WriteLine($"No of wings: {numberOfWings}");
            }

        }
        class RubberDuck : Duck
        {
            public RubberDuck(double weight,int numberWings,TypeOfDuck duckType)
                : base(weight, numberWings, duckType)
            {

            }
            public override void showDetails()
            {
                base.showDetails();
                Console.WriteLine("Rubber Duck doesn't fly and squeak");
            }

        }
        class MallardDuck : Duck
        {
            public MallardDuck(double weight, int numberWings, TypeOfDuck duckType)
                : base(weight, numberWings, duckType)
            {

            }
            public override void showDetails()
            {
                base.showDetails();
                Console.WriteLine("Mallard Duck fast fly and quack loud");
            }

        }
        class RedheadDuck : Duck
        {
            public RedheadDuck(double weight, int numberWings, TypeOfDuck duckType)
                : base(weight, numberWings, duckType)
            {

            }
            public override void showDetails()
            {
                base.showDetails();
                Console.WriteLine("Redhead Duck  fly slow and quack mild");
            }


        }
        static void Main(string[] args)
        {
            var ducks = new List<Duck>();
            ducks[0] = new RubberDuck(9, 2,TypeOfDuck.Rubber);
            ducks[1] = new RubberDuck(10, 4,TypeOfDuck.Mallard);
            ducks[2] = new RubberDuck(12, 6,TypeOfDuck.Redhead);
            foreach(var duck  in ducks)
            {
                duck.showDetails();
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
