using MarsRovers.Business.Interfaces;

namespace MarsRovers.Business.Command
{
    public class TurnRight : ICommand
    {
        readonly IRover rover;

        public TurnRight(IRover rover)
        {
            this.rover = rover;
        }

        public void Process()
        {
            this.rover.TurnRight();
        }
    }
}
