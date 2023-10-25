using ProductInventory.States;

namespace ProductInventory;
internal interface ICommand
{
    string Description { get; }

    IState Execute(IState currentState);
}

