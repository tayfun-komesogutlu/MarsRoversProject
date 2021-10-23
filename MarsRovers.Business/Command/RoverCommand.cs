using MarsRovers.Business.Interfaces;
using System.Collections.Generic;

namespace MarsRovers.Business.Command
{
    public class RoverCommand : IRoverCommand
    {
        public IRover Rover { get; set; }
        private readonly Queue<ICommand> commands = new();

        public RoverCommand(IRover rover)
        {
            this.Rover = rover;
        }

        public void AddCommand(ICommand command)
        {
            commands.Enqueue(command);
        }

        public void ProcessCommands()
        {
            while (commands.Count > 0)
            {
                ICommand command = commands.Dequeue();
                command.Process();
            }
        }
    }
}
