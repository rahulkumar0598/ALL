using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;

namespace Questions_15
{
    class ObservableCollection_Example
    {
        public static void NumbersChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.NewItems != null)
            {
                Console.WriteLine("Numbers Added");
                foreach (var number in args.NewItems)
                {
                    Console.Write(number + " ");
                }
            }
            Console.WriteLine();
            if (args.OldItems != null)
            {
                Console.WriteLine("Numbers Removed");
                foreach (var number in args.OldItems)
                {
                    Console.Write(number + " ");
                }
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            ObservableCollection<int> numbers = new ObservableCollection<int>();
            numbers.CollectionChanged += NumbersChanged;
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);

            numbers.Remove(1);
            numbers.Remove(2);
            numbers.Remove(3);
            numbers.Remove(4);
            numbers.Remove(5);
            Console.ReadLine();
        }
    }
}
