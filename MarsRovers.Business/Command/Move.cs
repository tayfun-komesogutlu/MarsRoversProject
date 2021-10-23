using MarsRovers.Business.Interfaces;


namespace MarsRovers.Business.Command
{
    public class Move : ICommand
    {
        readonly IRover rover;

        public Move(IRover rover)
        {
            this.rover = rover;
        }

        public void Process()
        {
            this.rover.Move();
        }
    }
}
