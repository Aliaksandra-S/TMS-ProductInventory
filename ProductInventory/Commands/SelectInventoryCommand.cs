using ProductInventory.States;

namespace ProductInventory.Commands;
internal class SelectInventoryCommand : ICommand
{
    private readonly InventoriesManager _inventories;
    private readonly FileOutputProvider _outputProvider;
    public SelectInventoryCommand(InventoriesManager inventories, FileOutputProvider outputProvider)
    {
        _inventories = inventories;
        _outputProvider = outputProvider;
    }

    public string Description => "Выбрать склад";

    public IState Execute(IState currentState)
    {
        Console.Write("Введите индекс: ");
        var input = Console.ReadLine();
        var index = -1;
        if (int.TryParse(input, out index) && _inventories.Contains(index))
        {
            return new InventoryState(currentState, _inventories.GetInventoryByIndex(index), _outputProvider);
        }
        else
        {
            Console.WriteLine("Такого склада нет!");
            Console.ReadKey();
            return currentState;
        }
    }
}
