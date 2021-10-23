using MarsRovers.Common.Enums;

namespace MarsRovers.Business.Interfaces
{
    public interface IRoverCordinate
    {
        int X { get; set; }
        int Y { get; set; }
        Cordinate cordinate { get; set; }
    }
}
