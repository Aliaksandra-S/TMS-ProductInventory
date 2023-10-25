using ProductInventory.States;

namespace ProductInventory.Commands;

internal class ExitCommand : ICommand
{
    public string Description => "Выйти из меню";

    public IState Execute(IState currentState)
    {
        return currentState.BackState();
    }
}
