using System.Text.Json;

namespace ProductInventory;
internal class JsonHandler
{
    public List<Product> ReadProductsFromJson(string path)
    {
        var json = File.ReadAllText(path);

        if (string.IsNullOrEmpty(json))
        {
            return null;
        }

        var products = new List<Product>();
        products = JsonSerializer.Deserialize<List<Product>>(json);

        return products;
    }

    public Inventory? ReadInventoryFromJson(string path)
    {
        var json = File.ReadAllText(path);

        if (string.IsNullOrEmpty(json))
        {
            return null;
        }
        
        return JsonSerializer.Deserialize<Inventory>(json);
    }

    public void WriteInventoryToJson(Inventory inventory, string path)
    {
        Clear(path);
        var dic = new Dictionary<Inventory, List<Product>>() { { inventory, inventory.Products } };
        string str = JsonSerializer.Serialize(inventory);
        File.WriteAllText(path, str);
    }

    public void Clear(string path)
    {
        File.WriteAllText(path, string.Empty);
    }
}

