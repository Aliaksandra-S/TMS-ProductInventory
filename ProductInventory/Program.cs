using ProductInventory;
using ProductInventory.States;

var directorySourcePath = ".\\SourceFiles\\Inventories";

var inventories = new InventoriesManager();

var jsonHandler = new JsonHandler();
var outputProvider = new FileOutputProvider(jsonHandler, directorySourcePath);

var files = Directory.GetFiles(directorySourcePath, "*.json");

if (files.Any())
{
    foreach (var file in files)
    {
        var inventory = jsonHandler.ReadInventoryFromJson(file);
        if (inventory != null)
        {
            inventories.AddInventory(inventory);
        }
    }
}

IState state = new StartState(inventories, outputProvider);
while (state != null)
{
    state = state.RunState();
}
