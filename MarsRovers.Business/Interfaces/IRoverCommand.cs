namespace MarsRovers.Business.Interfaces
{
    public interface IRoverCommand
    {
        IRover Rover { get; set; }
        void AddCommand(ICommand command);
        void ProcessCommands();
    }
}
