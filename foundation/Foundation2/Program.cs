using System;
using System.Collections.Generic;

public class Product
{
    private string name;
    private string productId;
    private float price;
    private int quantity;

    public Product(string name, string productId, float price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public string Name
    {
        get { return name; }
    }

    public string ProductId
    {
        get { return productId; }
    }

    public float Price
    {
        get { return price; }
    }

    public int Quantity
    {
        get { return quantity; }
    }

    public float GetTotalCost()
    {
        return price * quantity;
    }
}

public class Address
{
    private string street;
    private string city;
    private string state;
    private string zipCode; 
    private string country;
    public Address(string street, string city, string state, string zipCode, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.zipCode = zipCode;
        this.country = country;
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state} {zipCode}\n{country}";
    }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }
}

public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string Name
    {
        get { return name; }
    }

    public Address Address
    {
        get { return address; }
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }
}

public class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public float GetTotalCost()
    {
        float totalCost = 0;
        foreach (var product in products)
        {
            totalCost += product.GetTotalCost();
        }

        float shippingCost = customer.IsInUSA() ? 5f : 35f;
        return totalCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in products)
        {
            packingLabel += $"{product.Name} (ID: {product.ProductId})\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.Name}\n{customer.Address.GetFullAddress()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Anywhere St", "Salt Lake City", "UT", "84101", "USA");
        Address address2 = new Address("456 Somewhere Rd", "Rio de Janeiro", "RJ", "20000-000", "Brazil");

        Customer customer1 = new Customer("David Smith", address1);
        Customer customer2 = new Customer("Lindsay Smith", address2);

        Product product1 = new Product("Computer", "0001", 2000f, 1);
        Product product2 = new Product("Mouse", "0002", 20f, 2);
        Product product3 = new Product("Monitor", "0003", 200f, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}\n");
    }
}
