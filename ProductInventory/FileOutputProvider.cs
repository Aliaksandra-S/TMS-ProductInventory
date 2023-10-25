namespace ProductInventory;
internal class FileOutputProvider
{
    private readonly JsonHandler _jsonHandler;
    private readonly string _directory;

    public FileOutputProvider(JsonHandler jsonHandler, string outputDirectory)
    {
        _jsonHandler = jsonHandler;
        _directory = outputDirectory;
    }

    public void WriteResult(Inventory inventory)
    {
        _jsonHandler.WriteInventoryToJson(inventory, new string($"{_directory}\\{inventory.Name}.json"));
    }
}

