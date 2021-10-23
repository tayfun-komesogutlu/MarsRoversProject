using MarsRovers.Business.Interfaces;
using System.Collections.Generic;

namespace MarsRovers.Business.Dto
{
    public class Plateau : IPlateau
    {
        public int GridX { get; set; }
        public int GridY { get; set; }
        public bool CheckInit { get; private set; }
        public IList<IRover> Rovers { get; set; }

        public Plateau()
        {
            this.Rovers = new List<IRover>();
        }

        public Plateau(int X, int Y)
        {
            GridX = X;
            GridY = Y;
        }
        public bool Initialize(string gridSizeInput)
        {
            this.CheckInit = false;
            if (!string.IsNullOrWhiteSpace(gridSizeInput))
            {
                var gridSize = gridSizeInput.Split(' ');
                if (gridSize.Length == 2)
                {
                    if (int.TryParse(gridSize[0], out int X))
                    {
                        if (int.TryParse(gridSize[1], out int Y))
                        {
                            this.GridX = X;
                            this.GridY = Y;
                            this.CheckInit = true;
                        }
                    }

                }
            }
            return this.CheckInit;
        }
    }
}
