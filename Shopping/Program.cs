using System;
using System.Collections.Generic;

class Program
{
    static List<Product> shoppingCart = new List<Product>();
    static decimal discountPercent = 0;
    static string discountReason = "";

    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Shopping");
            Console.WriteLine("2. Quit");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ShoppingSubMenu();
                    break;
                case "2":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void ShoppingSubMenu()
    {
        bool backToMainMenu = false;

        while (!backToMainMenu)
        {
            Console.WriteLine("Shopping Sub Menu");
            Console.WriteLine("1. Add products to your shopping cart");
            Console.WriteLine("2. Include a discount");
            Console.WriteLine("3. Print shopping cart total");
            Console.WriteLine("4. Back to main menu");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            Console.WriteLine();

            switch (option)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    IncludeDiscount();
                    break;
                case "3":
                    PrintShoppingCartTotal();
                    break;
                case "4":
                    backToMainMenu = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AddProduct()
    {
        Console.WriteLine("Add Product to Shopping Cart");

        Console.Write("Product name: ");
        string name = Console.ReadLine();

        Console.Write("Product price: ");
        decimal price = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Product quantity: ");
        int quantity = Convert.ToInt32(Console.ReadLine());

        Product product = new Product(name, price, quantity);
        shoppingCart.Add(product);

        Console.WriteLine("Product added to the shopping cart.");
    }

    static void IncludeDiscount()
    {
        Console.WriteLine("Include Discount");

        Console.Write("Discount reason: ");
        string reason = Console.ReadLine();
        discountReason = reason;

        Console.Write("Discount percent: ");
        discountPercent = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Discount included.");
    }

    static void PrintShoppingCartTotal()
    {
        Console.WriteLine("Shopping Cart Total");

        decimal total = 0;
        int i = 1;
        foreach (var product in shoppingCart)
        {
            decimal subtotal = product.Price * product.Quantity;
            Console.WriteLine($"{product.Name}: {product.Price} x {product.Quantity} = {subtotal} (product {i})");
            i++;
            total += subtotal;
        }

        decimal discountAmount = total * (discountPercent / 100);
        decimal grandTotal = total - discountAmount;
        Console.WriteLine($"=================================================");
        Console.WriteLine($"{discountReason}         {discountPercent}%       =    {discountAmount}");

        Console.WriteLine($"=================================================");
        Console.WriteLine($"Total:                                            =     {grandTotal}");
    }
}

class Product
{
    public string Name { get; }
    public decimal Price { get; }
    public int Quantity { get; }

    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}