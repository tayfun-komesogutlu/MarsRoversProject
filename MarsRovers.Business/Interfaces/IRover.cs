using System.Collections.Generic;

namespace MarsRovers.Business.Interfaces
{
    public interface IRover :IEntityBase
    {
        IRoverCordinate CurrentCoordinate { get; }
        IPlateau PlateauGrid { get; set; }
        IList<ICommand> Commands { get; set; }
        void CommandParse(string roverCommandInput);
        void Move();
        void TurnRight();
        void TurnLeft();
    }
}
