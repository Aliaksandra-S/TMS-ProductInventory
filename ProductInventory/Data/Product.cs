namespace ProductInventory;

[Serializable]
internal class Product
{
    private string _sku;
    private string _name;
    private decimal _price;
    public string Sku
    {
        get => _sku;
        private set
        {
            if (value.Length != 4)
            {
                throw new ArgumentException("Идентификатор продукта должен состоять из 4 символов.");
            }
            _sku = value;
        }
    }
    public string Name
    {
        get => _name;
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Название продукта не должно быть пустым.");
            }
            _name = value;
        }
    }
    public decimal Price
    {
        get => _price;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Цена продукта должна быть неотрицательной.");
            }
            _price = value;
        }
    }

    public Product(string sku, string name, decimal price)
    {
        Sku = sku;
        Name = name;
        Price = price;
    }

    public static bool TryParse(string str, out Product product)
    {
        var splited = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        
        if (splited.Length != 3 || string.IsNullOrEmpty(splited[0]) || string.IsNullOrEmpty(splited[1]) || !decimal.TryParse(splited[2], out _))
        {
            product = null;
            return false;
        }

        product = new Product(splited[0], splited[1], decimal.Parse(splited[2]));
        return true;
    }

}
