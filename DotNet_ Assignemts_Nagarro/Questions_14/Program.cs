using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Questions_14
{
    class Product
    {
        public int id { get; set; }
        public float price { get; set; }
        public bool isDefective { get; set; }
        public Product()
        {

        }
        public Product(int id, float price, bool isDefective)
        {
            this.id = id;
            this.price = price;
            this.isDefective = isDefective;
        }
 
        
        public bool Equals(int id)
        {
            return this.id == id;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<Product, int>();
            int choice = -1;
            while (choice != 5)
            {
                Console.WriteLine("1 Add Product");
                Console.WriteLine("2 Remove Product");
                Console.WriteLine("3 Add Product Quantity");
                Console.WriteLine("4 Display Total Number of Inventory");
                Console.WriteLine("5 Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        int id = (new Random()).Next(1000, 1000);
                        Console.WriteLine( $"The product Id is {id}");
                        Console.WriteLine("Enter the product price");
                        float Price = float.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the product quantities");
                        int quantities = int.Parse(Console.ReadLine());
                        Console.WriteLine("Is this product Defective Yes/No");
                        string answer = Console.ReadLine();
                        bool isDefective = false;
                        if (answer.ToLower().CompareTo("yes") == 0)
                        {
                            isDefective = true;
                        }
                        Product product = new Product(id, Price, isDefective);
                        if (!product.isDefective)
                        {
                            products.Add(product, quantities);
                            Console.WriteLine(" A new product has been added");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter the product Id to remove");
                        id = int.Parse(Console.ReadLine());
                        Product selectedProduct = null;
                        foreach(var Product in products)
                        {
                            if (Product.Key.id == id)
                            {
                                selectedProduct = Product.Key;
                                break;
                            }
                        }
                        if (selectedProduct != null)
                        {
                            products.Remove(selectedProduct);
                            Console.WriteLine("The product has been removed");
                        }
                        else
                        {
                            Console.WriteLine("product does not exit");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter  the product id to update product");
                        id = int.Parse(Console.ReadLine());
                        selectedProduct = null;
                        foreach (var Product in products)
                        {
                            if (Product.Key.id== id)
                            {
                                selectedProduct = Product.Key;
                                break;
                            }
                        }
                        if (selectedProduct != null)
                        {
                            Console.WriteLine("Enter new product quantities: ");
                            quantities = int.Parse(Console.ReadLine());
                            products[selectedProduct] = quantities;
                            Console.WriteLine("The product has been updated");
                        }
                        else
                        {
                            Console.WriteLine("Product does not exit");
                        }
                        break;
                    case 4:
                        float total = 0;
                        foreach(var Product in products)
                        {
                            total = total + Product.Key.price * Product.Value;
                        }
                        Console.WriteLine($"The total value of inventory: {total.ToString("N2")}");
                        break;
                    case 5:
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}
