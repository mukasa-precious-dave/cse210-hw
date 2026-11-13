using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal productsTotal = 0;
        foreach (var product in _products)
        {
            productsTotal += product.GetTotalCost();
        }

        // Shipping cost: $5 if USA, $35 if international
        decimal shippingCost = _customer.LivesInUsa() ? 5.0m : 35.0m;
        return productsTotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("--- Packing Label ---");
        foreach (var product in _products)
        {
            sb.AppendLine($"- {product.GetName()} (ID: {product.GetProductId()})");
        }
        return sb.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("--- Shipping Label ---");
        sb.AppendLine(_customer.GetName());
        sb.AppendLine(_customer.GetAddress().GetFullAddress());
        return sb.ToString().TrimEnd();
    }
}