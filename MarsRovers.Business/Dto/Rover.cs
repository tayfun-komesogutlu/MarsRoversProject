using MarsRovers.Business.Command;
using MarsRovers.Business.Interfaces;
using MarsRovers.Common.Enums;
using MarsRovers.Common.Exceptions;
using System;
using System.Collections.Generic;

namespace MarsRovers.Business.Dto
{
    public class Rover : IRover
    {
        public IRoverCordinate CurrentCoordinate { get; private set; }
        public IPlateau PlateauGrid { get; set; }
        public IList<ICommand> Commands { get; set; }


        public Rover()
        {
            this.Commands = new List<ICommand>();
        }

        public Rover(IRoverCordinate roverCoordinate, IPlateau plateau)
        {
            this.CurrentCoordinate = roverCoordinate;
            this.PlateauGrid = plateau;
            this.Commands = new List<ICommand>();
        }
        public void Move()
        {

            this.CurrentCoordinate = RoverStatus.Move(this.CurrentCoordinate);
            CheckRoverIsAtValidGridBoundaries();
        }

        public void TurnLeft()
        {
            this.CurrentCoordinate.cordinate = RoverStatus.TurnLeft(this.CurrentCoordinate.cordinate);
        }

        public void TurnRight()
        {
            this.CurrentCoordinate.cordinate = RoverStatus.TurnRight(this.CurrentCoordinate.cordinate);
        }
        public bool Initialize(string roverCoordinateInput)
        {
            var roverCoordinate = roverCoordinateInput.Split(' ');
            if (roverCoordinate.Length == 3)
            {
                try
                {
                    var x = int.Parse(roverCoordinate[0]);
                    var y = int.Parse(roverCoordinate[1]);

                    var coordinate = roverCoordinate[2].ToUpper();
                    if (coordinate == "N" || coordinate == "S" || coordinate == "E" || coordinate == "W")
                    {
                        this.CurrentCoordinate.cordinate = (Cordinate)Enum.Parse(typeof(Cordinate), coordinate);
                        this.CurrentCoordinate.X = x;
                        this.CurrentCoordinate.Y = y;
                        return true;
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }


        public void CommandParse(string roverCommandInput)
        {
            foreach (var letter in roverCommandInput.ToCharArray())
            {
                switch (char.ToUpper(letter))
                {
                    case 'L':
                        //TurnLeft();
                        this.Commands.Add(new TurnLeft(this));
                        break;
                    case 'R':
                        //TurnRight();
                        this.Commands.Add(new TurnRight(this));
                        break;
                    case 'M':
                        //Move();
                        this.Commands.Add(new Move(this));
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }
        private void CheckRoverIsAtValidGridBoundaries()
        {
            var gridX = this.PlateauGrid.GridX;
            var gridY = this.PlateauGrid.GridY;
            var currentRoverPosition = this.CurrentCoordinate;

            if (currentRoverPosition.X > gridX || currentRoverPosition.X < 0)
            {
                throw new BoundaryException(gridX, currentRoverPosition.X, "X");
            }

            if (currentRoverPosition.Y > gridY || currentRoverPosition.Y < 0)
            {
                throw new BoundaryException(gridY, currentRoverPosition.Y, "Y");
            }
        }
    }
}
