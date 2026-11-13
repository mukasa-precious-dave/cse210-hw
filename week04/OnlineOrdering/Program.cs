using System;

class Program
{
    static void Main(string[] args)
    {
        // ----------------------------------------
        // ORDER 1: Domestic Customer (USA)
        // ----------------------------------------
        Address address1 = new Address("742 Evergreen Terrace", "Springfield", "OR", "USA");
        Customer customer1 = new Customer("Homer Simpson", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Doughnut Box", "DON-01", 6.99m, 3));
        order1.AddProduct(new Product("Desk Lamp", "LMP-44", 24.50m, 1));

        // ----------------------------------------
        // ORDER 2: International Customer (Canada)
        // ----------------------------------------
        Address address2 = new Address("100 Bay Street", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Sarah Connor", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Tactical Boots", "BTS-88", 120.00m, 1));
        order2.AddProduct(new Product("Wool Beanie", "BN-12", 18.75m, 2));
        order2.AddProduct(new Product("Multi-tool", "MT-99", 45.00m, 1));

        // ----------------------------------------
        // DISPLAY RESULTS
        // ----------------------------------------
        Console.WriteLine("========================================");
        Console.WriteLine("ORDER 1 (USA - Shipping: $5.00)");
        Console.WriteLine("========================================");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Order Cost: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine();

        Console.WriteLine("========================================");
        Console.WriteLine("ORDER 2 (International - Shipping: $35.00)");
        Console.WriteLine("========================================");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Order Cost: ${order2.CalculateTotalCost():F2}");
        Console.WriteLine("========================================");
    }
}