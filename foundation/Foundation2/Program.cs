using System;
using System.Collections.Generic;

public class Product
{
    private string _name;
    private string _productId;
    private float _price;
    private int _quantity;

    public Product(string name, string productId, float price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public string Name
    {
        get { return _name; }
    }

    public string ProductId
    {
        get { return _productId; }
    }

    public float Price
    {
        get { return _price; }
    }

    public int Quantity
    {
        get { return _quantity; }
    }

    public float GetTotalCost()
    {
        return _price * _quantity;
    }
}

public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _zipCode;
    private string _country;

    public Address(string street, string city, string state, string zipCode, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _zipCode = zipCode;
        _country = country;
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state} {_zipCode}\n{_country}";
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }
}

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string Name
    {
        get { return _name; }
    }

    public Address Address
    {
        get { return _address; }
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }
}

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public float GetTotalCost()
    {
        float totalCost = 0;
        foreach (var product in _products)
        {
            totalCost += product.GetTotalCost();
        }

        float shippingCost = _customer.IsInUSA() ? 5f : 35f;
        return totalCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in _products)
        {
            packingLabel += $"{product.Name} (ID: {product.ProductId})\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.Name}\n{_customer.Address.GetFullAddress()}";
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
        Product product2 = new Product("Mouse", "0002", 10f, 2);
        Product product3 = new Product("Monitor", "0003", 500f, 1);

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