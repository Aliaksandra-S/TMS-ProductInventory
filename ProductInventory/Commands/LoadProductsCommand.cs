using ProductInventory.States;

namespace ProductInventory.Commands;
internal class LoadProductsCommand : ICommand
{
    private readonly Inventory _inventory;
    private readonly FileOutputProvider _outputProvider;
    public LoadProductsCommand(Inventory inventory, FileOutputProvider outputProvider)
    {
        _inventory = inventory;
        _outputProvider = outputProvider;   

    }
    public string Description => "Загрузить продукты на склад";

    public IState Execute(IState currentState)
    {
        var jsonHandler = new JsonHandler();
        var products = jsonHandler.ReadProductsFromJson(".\\SourceFiles\\Products.json");
        if (products != null)
        {
            _inventory.AddRange(products);
            Console.WriteLine("Готово!");
        }
        else
        {
            Console.WriteLine("Файл пуст");
        }
        Console.ReadKey();

        _outputProvider.WriteResult(_inventory);

        return currentState;
    }
}
