using ProductInventory.Commands;

namespace ProductInventory.States;
internal class InventoryState : StateBase
{
    private readonly Inventory _inventory;
    private readonly FileOutputProvider _outputProvider;
    private readonly IState _previousState;

    protected override IState PreviousState => _previousState;

    protected override Dictionary<int, ICommand> Commands => new Dictionary<int, ICommand>()
    {
        {1, new LoadProductsCommand(_inventory, _outputProvider)},
        {2, new AddProductCommand(_inventory, _outputProvider)},
        {3, new RemoveProductCommand(_inventory, _outputProvider)},
        {0, new ExitCommand() }
    };

    public InventoryState(IState previousState, Inventory inventory, FileOutputProvider outputProvider)
    {
        _inventory = inventory;
        _outputProvider = outputProvider;
        _previousState = previousState;
    }

    protected override IState NextState(ICommand selectedCommand)
    {
        return selectedCommand.Execute(this);
    }

    protected override void ShowHead()
    {
        Console.Clear();
        Console.WriteLine($"\t* Меню склада {_inventory.Name} *\n\n" +
            $"Количество продуктов: {_inventory.ProductCount}  |  Cтоимость: {_inventory.TotalCost}\n");
    }
}

