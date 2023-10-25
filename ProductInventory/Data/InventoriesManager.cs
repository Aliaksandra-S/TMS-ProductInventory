namespace ProductInventory;
internal class InventoriesManager
{
    private List<Inventory> _inventories;

    public InventoriesManager()
    {
        _inventories = new List<Inventory>();
    }

    public int InventoriesCount => _inventories.Count;
    public void AddInventory(Inventory inventory)
    {
        _inventories.Add(inventory);
    }

    public bool Contains(int index)
    {
        return index <= _inventories.Count && index >= 1;
    }

    public Inventory GetInventoryByIndex(int index)
    {
        return _inventories[index - 1];
    }
    public void ShowInventoriesList()
    {
        for (int i = 0; i < _inventories.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {_inventories[i].Name}");
        }
    }
}

