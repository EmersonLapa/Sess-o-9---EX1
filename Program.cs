using System;
using EX2.Entities;
using EX2.Entities.Enums;
using System.Globalization;
namespace EX2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine(); 
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Client client = new Client(name, email, date);
            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Order order = new Order(DateTime.Now, status, client);
            Console.Write("How many items to this order ? ");
            int numItems = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numItems; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                string nameProd = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                Product product = new Product(nameProd, price);
                OrderItem orderItem = new OrderItem(quantity, price, product);
                order.AddItem(orderItem);
            }
            Console.WriteLine(order);

        }
    }
}
