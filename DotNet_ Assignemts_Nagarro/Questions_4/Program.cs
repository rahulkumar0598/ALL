using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions_4
{
    public enum TypeOfEquipment { mobile,immobile}

    public abstract class Equipment
    {
        string name { get; set; }
        string description { get; set; }
        public float distanceMovedTillDate { get; set; }
        public float maintenanceCost { get; set; }
        public Equipment()
        {
            this.distanceMovedTillDate = 0;
            this.maintenanceCost = 0;
        }
        public void GetDetails()
        {
            Console.WriteLine("Name of the equipment");
            name = Console.ReadLine();
            Console.WriteLine("Enter Description of Equipment");
            description = Console.ReadLine();
        }
        public virtual void MoveBy(int distanceMove)
        {

        }
        public void ShowDetails()
        {
            Console.WriteLine($"Name {name}");
            Console.WriteLine($"Description {description}");
            Console.WriteLine($"Distance Move till Date {distanceMovedTillDate}");
            Console.WriteLine($"Maintenance Cost {maintenanceCost}");
        }

    }
    public class Mobile : Equipment
    {
        public int noOfWheels;
        public void GetMobileDetail()
        {
            Console.WriteLine("Enter No of Wheels of Equipment");
            noOfWheels = Convert.ToInt32(Console.ReadLine());
        }
        public override void MoveBy(int distanceMove)
        {
            distanceMovedTillDate = distanceMovedTillDate + distanceMove;
            maintenanceCost = noOfWheels * distanceMovedTillDate;
        }
    }
    public class Immobile : Equipment
    {
        public float weight;
        public void GetImmobileDetails()
        {
            Console.WriteLine("Enter the weight of immobile Equipment");
            weight = Convert.ToInt32(Console.ReadLine());
        }
        public override void MoveBy(int distanceMove)
        {
            distanceMovedTillDate = distanceMovedTillDate + distanceMove;
            maintenanceCost = weight * distanceMovedTillDate;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the value 0 for mobile and 1 for immobile");
            int number = int.Parse(Console.ReadLine());
            if (number == (int)TypeOfEquipment.mobile)
            {
                var movingEquipment = new Mobile();
                movingEquipment.GetDetails();
                movingEquipment.GetMobileDetail();
                movingEquipment.MoveBy(4);
                movingEquipment.ShowDetails();

            }
            else if (number == (int)TypeOfEquipment.immobile)
            {
                var notMovingEquipment = new Immobile();
                notMovingEquipment.GetDetails();
                notMovingEquipment.GetImmobileDetails();
                notMovingEquipment.MoveBy(9);
                notMovingEquipment.ShowDetails();
            }
            else
            {
                Console.WriteLine("wrong value entered:Please enter the value 0 for " +
                    "mobile and 1 for immobile ");
            }
            Console.ReadLine();
        }
    }
}