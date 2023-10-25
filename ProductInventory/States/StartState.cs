using ProductInventory.Commands;

namespace ProductInventory.States;
internal class StartState : StateBase
{
    private readonly InventoriesManager _inventoriesManager;
    private readonly FileOutputProvider _outputProvider;

    protected override IState PreviousState => null;

    protected override Dictionary<int, ICommand> Commands => new Dictionary<int, ICommand>()
    {
        {1, new SelectInventoryCommand(_inventoriesManager, _outputProvider)},
        {2, new CreateInventoryCommand(_inventoriesManager, _outputProvider)},
        {0, new ExitCommand()},
    };

    public StartState(InventoriesManager inventoriesManager, FileOutputProvider outputProvider)
    {
        _inventoriesManager = inventoriesManager;
        _outputProvider = outputProvider;
    }

    protected override void ShowHead()
    {
        Console.Clear();
        Console.WriteLine("\t* Главное меню *\n");
        Console.WriteLine($"Доступно складов: {_inventoriesManager.InventoriesCount}");
        _inventoriesManager.ShowInventoriesList();
    }

    protected override IState NextState(ICommand selectedCommand)
    {
        return selectedCommand.Execute(this);
    }
}

