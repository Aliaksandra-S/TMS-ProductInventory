namespace ProductInventory.States
{
    internal abstract class StateBase : IState
    {
        protected abstract IState PreviousState { get; }

        protected abstract Dictionary<int, ICommand> Commands { get; }

        protected abstract void ShowHead();

        protected virtual void ShowCommands()
        {
            Console.WriteLine("\nВыберите действие:");
            foreach (var command in Commands)
            {
                Console.WriteLine($"{command.Key} - {command.Value.Description}");
            }
        }

        protected virtual ICommand ReadCommand()
        {   
            Console.Write("\nВвод: ");
            var input = Console.ReadLine();
            var selected = -1;

            if (int.TryParse(input, out selected) && Commands.ContainsKey(selected))
            {
                return Commands[selected];
            }
            else
            {
                Console.WriteLine("Некорректный ввод!");
                return ReadCommand();
            }
        }

        public virtual IState RunState()
        {
            ShowHead();
            ShowCommands();
            var command = ReadCommand();
            return NextState(command);
        }

        public IState BackState()
        {
            return PreviousState;
        }

        protected abstract IState NextState(ICommand selectedCommand);
    }
}
