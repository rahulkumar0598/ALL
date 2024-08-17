using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_6
{
    public enum TypeOfEquipment { mobile, immobile }
    public abstract class Equipment
    {
        public string Name;
        public string Description;
        public float DistanceMovedTillDate;
        public float MaintenanceCost;
        public int Type;
        public Equipment()
        {
            DistanceMovedTillDate = 0;
            MaintenanceCost = 0;
        }

        public void GetDetails()
        {
            Console.WriteLine("Enter the Name of the Equipment");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Description of Equipment");
            Description = Console.ReadLine();
        }
        public abstract void GetTypeDetail();
        public virtual void MoveBy(int distanceToMove)
        {

        }
        public void ShowDetails()
        {
            Console.WriteLine("\t\tName : {0} ", Name);
            Console.WriteLine("\t\tDescription : {0}", Description);
            Console.WriteLine("\t\tDistance moved till date : {0}", DistanceMovedTillDate);
            Console.WriteLine("\t\tMaintenance cost : {0}", MaintenanceCost);
        }
    }
    public class Mobile : Equipment
    {
        public int NoOfWheels;
        public Mobile()
        {
            Type = (int)TypeOfEquipment.mobile;
        }
        public override void GetTypeDetail()
        {
            Console.WriteLine("Enter No. of wheels of equipment");
            NoOfWheels = Convert.ToInt32(Console.ReadLine());
        }
        public override void MoveBy(int distanceToMove)
        {
            DistanceMovedTillDate += distanceToMove;
            MaintenanceCost = NoOfWheels * DistanceMovedTillDate;
        }
    }
    public class Immobile : Equipment
    {
        public float Weight;
        public Immobile()
        {
            Type = (int)TypeOfEquipment.immobile;
        }
        public override void GetTypeDetail()
        {
            Console.WriteLine("Enter Weight of Immobile Equipment");
            Weight = Convert.ToInt32(Console.ReadLine());
        }
        public override void MoveBy(int distanceToMove)
        {
            DistanceMovedTillDate += distanceToMove;
            MaintenanceCost = Weight * DistanceMovedTillDate;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
       
            List<Equipment> ListofAllEquipments = new List<Equipment>(); 
            Equipment e1 = new Mobile();
            e1.GetDetails();
            ListofAllEquipments.Add(e1);
            Equipment e2 = new Immobile();
            e2.GetDetails();
            ListofAllEquipments.Add(e2);
            Equipment e3 = new Mobile();
            e3.GetDetails();
            ListofAllEquipments.Add(e3);
            Equipment e4 = new Mobile();
            e4.GetDetails();
            ListofAllEquipments.Add(e4);
            Equipment e5 = new Immobile();
            e5.GetDetails();
            ListofAllEquipments.Add(e5);
            Console.WriteLine();

            //2. Deleting an equipement
            ListofAllEquipments.Remove(e5);

            //3. Moving a mobile equipment
            Console.WriteLine("Enter the Name of the Mobile Equipment to Move");
            string mobileEquipment = Console.ReadLine();
            var moveMobile = from equipment in ListofAllEquipments
                             where (equipment.Type == 0 && equipment.Name == mobileEquipment)
                             select equipment;
            foreach (var equipment in moveMobile)
            {
                equipment.GetTypeDetail();
                equipment.MoveBy(10);
            }
            //3. Moving an immobile equipment
            Console.WriteLine("Enter the name of the immobile equipment to move");
            string ImmobileEquipment = Console.ReadLine();
            var moveImmobile = from equipment in ListofAllEquipments
                               where (equipment.Type == 1 && equipment.Name == ImmobileEquipment)
                               select equipment;
            foreach (var equipment in moveImmobile)
            {
                equipment.GetTypeDetail();
                equipment.MoveBy(10);
            }

            //4. Basic DetailsListing all equipments 
            var result = from equipment in ListofAllEquipments
                         select equipment;
            foreach (var equipment in result)
            {
                Console.WriteLine("Name : {0}", equipment.Name);
                Console.WriteLine("Description : {0}", equipment.Description);
            }
            Console.WriteLine();

            //5. Showing all details of an equipment
            Console.WriteLine("Enter the name of the equipment to show details");
            string showEquipment = Console.ReadLine();
            var show = from equipment in ListofAllEquipments
                       where equipment.Name == showEquipment
                       select equipment;
            foreach (var equipment in show)
            {
                equipment.ShowDetails();
            }
            Console.WriteLine();

            //6. All mobile equipments
            foreach (var equipment in ListofAllEquipments.FindAll(e => (e.Type == 0)))
            {
                Console.WriteLine("{0} : {1}", equipment.Name, equipment.Description);
            }
            Console.WriteLine();

            //7. All immobile equipments
            foreach (var equipment in ListofAllEquipments.FindAll(e => (e.Type == 1)))
            {
                Console.WriteLine("{0} : {1}", equipment.Name, equipment.Description);
            }
            Console.WriteLine();

            //8. Equipments that have not been moved till now
            var NotMoved = from equipment in ListofAllEquipments
                           where (equipment.DistanceMovedTillDate == 0)
                           select equipment;
            foreach (var equipment in NotMoved)
            {
                equipment.ShowDetails();
            }
            Console.WriteLine();

            //9. Deleting all equipments
            ListofAllEquipments.Clear();
            //Enter some new equipment for futher operation i.e  one may be mobile or  other may be immobile
            Equipment e6 = new Mobile();
            e6.GetDetails();
            ListofAllEquipments.Add(e6);
            Equipment e7 = new Immobile();
            e7.GetDetails();
            ListofAllEquipments.Add(e7);

            //10. Deleting all immobile equipment
            ListofAllEquipments.RemoveAll(e => e.Type == 1);
            foreach (var equipment in ListofAllEquipments)
            {
                Console.WriteLine("Name : {0}" , equipment.Name);
            }

            //11. Deleting all mobile equipments
            ListofAllEquipments.RemoveAll(e => e.Type == 0);
            foreach (var equipment in ListofAllEquipments)
            {
                Console.WriteLine("Name : {0}", equipment.Name);
            }

         
        }
    }
}
