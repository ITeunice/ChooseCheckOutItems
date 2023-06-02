using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>();
        List<Product> cart = new List<Product>();

        while (true)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Add product");
            Console.WriteLine("2. Remove product");
            Console.WriteLine("3. Edit product");
            Console.WriteLine("4. Display all products");
            Console.WriteLine("5. Add to cart");
            Console.WriteLine("6. Remove from cart");
            Console.WriteLine("7. View cart");
            Console.WriteLine("8. Checkout");
            Console.WriteLine("9. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct(products);
                    break;
                case "2":
                    RemoveProduct(products);
                    break;
                case "3":
                    EditProduct(products);
                    break;
                case "4":
                    DisplayProducts(products);
                    break;
                case "5":
                    AddToCart(products, cart);
                    break;
                case "6":
                    RemoveFromCart(cart);
                    break;
                case "7":
                    ViewCart(cart);
                    break;
                case "8":
                    Checkout(cart);
                    break;
                case "9":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AddProduct(List<Product> products)
    {
        Console.WriteLine("Enter the product name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter the product price:");
        double price = double.Parse(Console.ReadLine());

        Product newProduct = new Product(name, price);
        products.Add(newProduct);

        Console.WriteLine("Product added successfully.");
    }

    static void RemoveProduct(List<Product> products)
    {
        Console.WriteLine("Enter the product name to remove:");
        string name = Console.ReadLine();

        Product productToRemove = products.Find(p => p.Name.Equals(name));

        if (productToRemove != null)
        {
            products.Remove(productToRemove);
            Console.WriteLine("Product removed successfully.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    static void EditProduct(List<Product> products)
    {
        Console.WriteLine("Enter the product name to edit:");
        string name = Console.ReadLine();

        Product productToEdit = products.Find(p => p.Name.Equals(name));

        if (productToEdit != null)
        {
            Console.WriteLine("Enter the new product name:");
            string newName = Console.ReadLine();

            Console.WriteLine("Enter the new product price:");
            double newPrice = double.Parse(Console.ReadLine());

            productToEdit.Name = newName;
            productToEdit.Price = newPrice;

            Console.WriteLine("Product edited successfully.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    static void DisplayProducts(List<Product> products)
    {
        if (products.Count > 0)
        {
            Console.WriteLine("Products in the store:");
            foreach (Product product in products)
            {
                Console.WriteLine($"Name: {product.Name}, Price: {product.Price}");
            }
        }
        else
        {
            Console.WriteLine("No products in the store.");
        }
    }

    static void AddToCart(List<Product> products, List<Product> cart)
    {
        Console.WriteLine("Enter the product name to add to cart:");
        string name = Console.ReadLine();

        Product productToAdd = products.Find(p => p.Name.Equals(name));

        if (productToAdd != null)
        {
            cart.Add(productToAdd);
            Console.WriteLine("Product added to cart successfully.");
        }
        else
        {
            Console.WriteLine("Product not found in the store.");
        }
    }

    static void RemoveFromCart(List<Product> cart)
    {
        Console.WriteLine("Enter the product name to remove from cart:");
        string name = Console.ReadLine();

        Product productToRemove = cart.Find(p => p.Name.Equals(name));

        if (productToRemove != null)
        {
            cart.Remove(productToRemove);
            Console.WriteLine("Product removed from cart successfully.");
        }
        else
        {
            Console.WriteLine("Product not found in the cart.");
        }
    }

    static void ViewCart(List<Product> cart)
    {
        if (cart.Count > 0)
        {
            Console.WriteLine("Products in the cart:");
            foreach (Product product in cart)
            {
                Console.WriteLine($"Name: {product.Name}, Price: {product.Price}");
            }
        }
        else
        {
            Console.WriteLine("Cart is empty.");
        }
    }

    static void Checkout(List<Product> cart)
    {
        if (cart.Count > 0)
        {
            double total = 0;

            Console.WriteLine("Cart items:");
            foreach (Product product in cart)
            {
                Console.WriteLine($"Name: {product.Name}, Price: {product.Price}");
                total += product.Price;
            }

            Console.WriteLine($"Total: {total}");

            // Additional logic to allow selecting multiple items for checkout
            Console.WriteLine("Enter the names of the items to checkout (separated by comma):");
            string[] itemsToCheckout = Console.ReadLine().Split(',');

            foreach (string itemName in itemsToCheckout)
            {
                string trimmedItemName = itemName.Trim();

                Product productToCheckout = cart.Find(p => p.Name.Equals(trimmedItemName));

                if (productToCheckout != null)
                {
                    cart.Remove(productToCheckout);
                    Console.WriteLine($"Item '{trimmedItemName}' checked out successfully.");
                }
                else
                {
                    Console.WriteLine($"Item '{trimmedItemName}' not found in the cart.");
                }
            }

            Console.WriteLine("Checkout completed. Cart updated.");
        }
        else
        {
            Console.WriteLine("Cart is empty. Nothing to checkout.");
        }
    }
}

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }
}

