using System;

namespace OnlineOrderingSystem
{
    class Program
    {
        static void Main()
        {
            // Create addresses
            Address address1 = new Address("407 Bakanoo St", "Cape Coast", "CC", "Ghana");
            Address address2 = new Address("212 PTI St", "Takoradi", "TD", "Togo");

            // Create customers
            Customer customer1 = new Customer("Damian Adetaba", address1);
            Customer customer2 = new Customer("Judith Apaa", address2);

            // Create products
            Product product1 = new Product("Laptop", "A123", 999.99m, 1);
            Product product2 = new Product("Iphone", "B456", 25.50m, 2);
            Product product3 = new Product("Television", "C789", 45.00m, 1);
            Product product4 = new Product("Washing Machine", "D012", 200.00m, 1);

            // Create orders and add products to them
            Order order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);

            Order order2 = new Order(customer2);
            order2.AddProduct(product3);
            order2.AddProduct(product4);

            // Display information for order 1
            Console.WriteLine("Order 1:");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Cost: GH {order1.GetTotalCost()}");

            Console.WriteLine();

            // Display information for order 2
            Console.WriteLine("Order 2:");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Cost: GH {order2.GetTotalCost()}");
        }
    }
}
