
using ProductInventory.States;

namespace ProductInventory.Commands;

internal class CreateInventoryCommand : ICommand
{
    private readonly InventoriesManager _inventories;
    private readonly FileOutputProvider _outputProvider;
    public CreateInventoryCommand(InventoriesManager inventories, FileOutputProvider outputProvider)
    {
        _inventories = inventories;
        _outputProvider = outputProvider;
    }

    public string Description => "Создать новый склад";

    public IState Execute(IState currentState)
    {
        Console.Write("Введите имя склада: ");
        var input = Console.ReadLine();

        var inventory = new Inventory(input);
        _inventories.AddInventory(inventory);

        _outputProvider.WriteResult(inventory);

        return currentState;
    }
}

