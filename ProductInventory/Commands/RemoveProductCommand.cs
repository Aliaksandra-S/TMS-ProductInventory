using ProductInventory.States;

namespace ProductInventory.Commands;

internal class RemoveProductCommand : ICommand
{
    private readonly Inventory _inventory;
    private readonly FileOutputProvider _outputProvider;
    public RemoveProductCommand(Inventory inventory, FileOutputProvider outputProvider)
    { 
        _inventory = inventory;
        _outputProvider = outputProvider;
    }

    public string Description => "Удалить продукт";

    public IState Execute(IState currentState)
    {
        Console.Write("Введите SKU продукта: ");
        var input = Console.ReadLine();
        var product = _inventory.GetProductBySku(input);

        if (product == null)
        {
            Console.WriteLine($"Такого на складе {_inventory.Name} нет.");
        }
        else
        {
            _inventory.RemoveProduct(product);

           _outputProvider.WriteResult(_inventory);

            Console.WriteLine("Удален.");
        }
        Console.ReadKey();

        return currentState;
    }
}

