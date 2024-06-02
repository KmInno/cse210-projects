using System;
using System.Collections.Generic;

// Address class
class Address
{
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _country;

    // Constructor
    public Address(string streetAddress, string city, string state, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _state = state;
        _country = country;
    }

    // Method to detect if the address is in the USA
    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    // Method to get the full address as a string
    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_state}\n{_country}";
    }
}

// Customer class
class Customer
{
    private string _customerName;
    private Address _address;

    // Constructor
    public Customer(string customerName, Address address)
    {
        _customerName = customerName;
        _address = address;
    }

    // Method to verify if the customer is in the USA
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    // Method to get the customer's full address
    public string GetAddress()
    {
        return _address.GetFullAddress();
    }

    // Getter for customer name
    public string GetName()
    {
        return _customerName;
    }
}

// Product class
class Product
{
    private string _productName;
    private int _productId;
    private double _price;
    private int _quantity;

    // Constructor
    public Product(string productName, int productId, double price, int quantity)
    {
        _productName = productName;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    // Method to compute the total cost of the product
    public double ComputeTotalProductCost()
    {
        return _price * _quantity;
    }

    // Getter for product name
    public string GetName()
    {
        return _productName;
    }

    // Getter for product ID
    public int GetProductId()
    {
        return _productId;
    }
}

// Order class
class Order
{
    private List<Product> _listOfProducts;
    private Customer _customer;

    // Constructor
    public Order(List<Product> products, Customer customer)
    {
        _listOfProducts = products;
        _customer = customer;
    }

    // Method to calculate the total cost of the order
    public double CalculateTotalCostOfOrder()
    {
        double totalCost = 0;
        foreach (var product in _listOfProducts)
        {
            totalCost += product.ComputeTotalProductCost();
        }
        totalCost += CalculateShippingCost();
        return totalCost;
    }

    // Method to calculate the shipping cost
    private double CalculateShippingCost()
    {
        return _customer.IsInUSA() ? 5.0 : 35.0;
    }

    // Method to get the packing label string
    public string PackingLabelString()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in _listOfProducts)
        {
            packingLabel += $"Product Name: {product.GetName()}, Product ID: {product.GetProductId()}\n";
        }
        return packingLabel;
    }

    // Method to get the shipping label string
    public string ShippingLabelString()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress()}";
    }
}

// Main program class
class Program
{
    static void Main(string[] args)
    {
        // Create some address objects
        Address address1 = new Address("123 Maple St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Elm St", "Vancouver", "BC", "Canada");

        // Create some customer objects
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create some product objects
        Product product1 = new Product("Widget", 1001, 10.0, 2);
        Product product2 = new Product("Gadget", 1002, 15.0, 1);
        Product product3 = new Product("Doodad", 1003, 7.5, 3);
        Product product4 = new Product("Thingamajig", 1004, 20.0, 1);

        // Create some orders with products
        Order order1 = new Order(new List<Product> { product1, product2 }, customer1);
        Order order2 = new Order(new List<Product> { product3, product4 }, customer2);

        // List of orders
        List<Order> orders = new List<Order> { order1, order2 };

        // Display details of each order
        foreach (var order in orders)
        {
            Console.WriteLine(order.PackingLabelString());
            Console.WriteLine(order.ShippingLabelString());
            Console.WriteLine($"Total Cost: ${order.CalculateTotalCostOfOrder()}\n");
        }
    }
}
