namespace ProductInventory.States;
internal interface IState
{
    IState RunState();
    IState BackState();
}

