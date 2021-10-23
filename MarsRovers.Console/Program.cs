using MarsRovers.Business.Interfaces;
using MarsRovers.Common.Constants;
using MarsRovers.Console.Container;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRovers.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Ioc.Configure();

            var plateauArea = serviceProvider.GetService<IPlateau>();

            while (!plateauArea.CheckInit)
            {
                System.Console.WriteLine("Dimension size :");
                var plateauAreaInput = System.Console.ReadLine();

                if (!plateauArea.Initialize(plateauAreaInput))
                {
                    System.Console.WriteLine(InputInformation.PlateuSizeInfo);
                }
            }

            var addAnotherRover = true;

            while (addAnotherRover)
            {
                System.Console.WriteLine("Rover cordinate  :");
                var roverPositionInput = System.Console.ReadLine();


                System.Console.WriteLine("Rover command (L: left R : Right M : Move) :");
                var roverCommandInput = System.Console.ReadLine();

                var rover = serviceProvider.GetService<IRover>();
                if (rover.Initialize(roverPositionInput))
                {
                    rover.PlateauGrid = plateauArea;
                    rover.CommandParse(roverCommandInput);
                    plateauArea.Rovers.Add(rover);
                }
                else
                {
                    System.Console.WriteLine(InputInformation.RoverCommandInfo);

                }

                System.Console.WriteLine("Another Rover ? Yes or No  (Y)");

                var addAnotherRoverInput = System.Console.ReadLine();
                if (addAnotherRoverInput.ToUpper() != "Y")
                {
                    addAnotherRover = false;
                }
            }
            System.Console.WriteLine("Output :");

            foreach (var rover in plateauArea.Rovers)
            {
                var roverCommands = serviceProvider.GetService<IRoverCommand>();
                roverCommands.Rover = rover;

                foreach (var roverCommand in rover.Commands)
                {
                    roverCommands.AddCommand(roverCommand);
                }

                roverCommands.ProcessCommands();

                System.Console.WriteLine($"{roverCommands.Rover.CurrentCoordinate.X} " +
                  $"{roverCommands.Rover.CurrentCoordinate.Y} " +
                  $"{roverCommands.Rover.CurrentCoordinate.cordinate.ToString()}");
            }

            System.Console.ReadKey();
        }
    }
}

