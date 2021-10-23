using System;

namespace MarsRovers.Common.Exceptions
{
    public class BoundaryException : Exception
    {
        public BoundaryException(int boundary, int real, string grid)
           : base($"Outofboundary on grid {grid}. (Boundary limit: {boundary}, Real: {real})")
        {
            Boundary = boundary;
            Real = real;
            Grid = grid;
        }

        public string Grid { get; set; }
        public int Boundary { get; set; }
        public int Real { get; set; }
    }
}
