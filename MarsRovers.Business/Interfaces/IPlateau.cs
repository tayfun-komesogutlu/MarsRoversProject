using System.Collections.Generic;

namespace MarsRovers.Business.Interfaces
{
    public interface IPlateau : IEntityBase
    {
        int GridX { get; set; }
        int GridY { get; set; }
        bool CheckInit { get; }
        IList<IRover> Rovers { get; set; }
    }
}
