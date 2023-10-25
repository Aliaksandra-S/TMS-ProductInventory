using System.Text.Json.Serialization;

namespace ProductInventory;

[Serializable]
internal class Inventory
{
    private List<Product> _products;
    public string Name { get; private set; }
    public List<Product> Products { get => new List<Product>(_products); private set => _products = value; }

    public int ProductCount => _products.Count;

    public decimal TotalCost => _products.Sum(x => x.Price);

    public Inventory() { }

    public Inventory(string name) 
    {
        Name = name;
        Products = new List<Product>();
    }

    [JsonConstructor]
    public Inventory(string name, List<Product> products) 
    {
        Name = name;
        _products = products;
    }
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public void AddRange(List<Product> products)
    {
        _products.AddRange(products);
    }

    public bool RemoveProduct(Product product)
    {
        return _products.Remove(product);
    }

    public Product? GetProductBySku(string sku)
    {
        return _products.Where(x => x.Sku == sku).FirstOrDefault();
    }
}

