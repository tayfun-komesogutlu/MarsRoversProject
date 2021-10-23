using MarsRovers.Business.Interfaces;
using MarsRovers.Common.Enums;

namespace MarsRovers.Business.Command
{
    public class RoverCordinate : IRoverCordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Cordinate cordinate { get; set; }

        public RoverCordinate(Cordinate coordinate = Cordinate.N, int x = 0, int y = 0)
        {
            this.X = x;
            this.Y = y;
            this.cordinate = coordinate;
        }
    }
}

