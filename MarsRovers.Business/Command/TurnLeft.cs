using MarsRovers.Business.Interfaces;

namespace MarsRovers.Business.Command
{
    public class TurnLeft : ICommand
    {
        readonly IRover rover;

        public TurnLeft(IRover rover)
        {
            this.rover = rover;
        }

        public void Process()
        {
            this.rover.TurnLeft();
        }
    }
}
