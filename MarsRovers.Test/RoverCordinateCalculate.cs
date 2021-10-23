using MarsRovers.Business.Command;
using MarsRovers.Business.Dto;
using MarsRovers.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MarsRovers.Test
{
    public class RoverCordinateCalculate
    {
        [Fact]
        public void Return_Coordinate_Calculate_Happy_Path()
        {
            var plateauGrid1 = new Plateau(5, 5);

            var roverPosition = new RoverCordinate(Cordinate.N, 1, 2);
            var rover = new Rover(roverPosition, plateauGrid1);

            var roverCommandManager = new RoverCommand(rover);
            roverCommandManager.AddCommand(new TurnLeft(rover));
            roverCommandManager.AddCommand(new Move(rover));
            roverCommandManager.AddCommand(new TurnLeft(rover));
            roverCommandManager.AddCommand(new Move(rover));
            roverCommandManager.AddCommand(new TurnLeft(rover));
            roverCommandManager.AddCommand(new Move(rover));
            roverCommandManager.AddCommand(new TurnLeft(rover));
            roverCommandManager.AddCommand(new Move(rover));
            roverCommandManager.AddCommand(new Move(rover));

            roverCommandManager.ProcessCommands();
            var actualOutput = $"{roverCommandManager.Rover.CurrentCoordinate.X} {roverCommandManager.Rover.CurrentCoordinate.Y } {roverCommandManager.Rover.CurrentCoordinate.cordinate}";
            var expectedOutput = "1 3 N";

            Assert.Equal(expectedOutput, actualOutput);

        }

        [Fact]
        public void Return_Coordinate_Calculate_Happy_Path2()
        {
            var plateauGrid1 = new Plateau(5, 5);

            var roverPosition = new RoverCordinate(Cordinate.E, 3, 3);
            var rover = new Rover(roverPosition, plateauGrid1);

            var roverCommandManager = new RoverCommand(rover);
            roverCommandManager.AddCommand(new Move(rover));
            roverCommandManager.AddCommand(new Move(rover));
            roverCommandManager.AddCommand(new TurnRight(rover));
            roverCommandManager.AddCommand(new Move(rover));
            roverCommandManager.AddCommand(new Move(rover));
            roverCommandManager.AddCommand(new TurnRight(rover));
            roverCommandManager.AddCommand(new Move(rover));
            roverCommandManager.AddCommand(new TurnRight(rover));
            roverCommandManager.AddCommand(new TurnRight(rover));
            roverCommandManager.AddCommand(new Move(rover));


            roverCommandManager.ProcessCommands();
            var actualOutput = $"{roverCommandManager.Rover.CurrentCoordinate.X} {roverCommandManager.Rover.CurrentCoordinate.Y } {roverCommandManager.Rover.CurrentCoordinate.cordinate}";
            var expectedOutput = "5 1 E";

            Assert.Equal(expectedOutput, actualOutput);

        }
    }
}
