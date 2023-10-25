using ProductInventory.States;

namespace ProductInventory.Commands;
internal class AddProductCommand : ICommand
{
    private readonly Inventory _inventory;
    private readonly FileOutputProvider _outputProvider;
    public AddProductCommand(Inventory inventory, FileOutputProvider outputProvider)
    {
        _inventory = inventory;
        _outputProvider = outputProvider;
    }

    public string Description => "Добавить новый продукт";

    public IState Execute(IState currentState)
    {
        Console.WriteLine("Введите 4-х значный код, наименование и цену продукта через пробел: ");;
        var input = Console.ReadLine();

        Product product = null;
        Product.TryParse(input, out product);

        _inventory.AddProduct(product);

        _outputProvider.WriteResult(_inventory);
        return currentState;
    }
}

