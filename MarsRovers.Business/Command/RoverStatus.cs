using MarsRovers.Business.Interfaces;
using MarsRovers.Common.Enums;
using System;

namespace MarsRovers.Business.Command
{
    public class RoverStatus
    {
        public static IRoverCordinate Move(IRoverCordinate roverCordinate)
        {
            IRoverCordinate currentRoverCordinate = roverCordinate.cordinate switch
            {
                Cordinate.N => new RoverCordinate(roverCordinate.cordinate, roverCordinate.X, roverCordinate.Y + 1),
                Cordinate.S => new RoverCordinate(roverCordinate.cordinate, roverCordinate.X, roverCordinate.Y - 1),
                Cordinate.W => new RoverCordinate(roverCordinate.cordinate, roverCordinate.X - 1, roverCordinate.Y),
                Cordinate.E => new RoverCordinate(roverCordinate.cordinate, roverCordinate.X + 1, roverCordinate.Y),
                _ => throw new InvalidOperationException(),
            };
            return currentRoverCordinate;
        }

        public static Cordinate TurnRight(Cordinate roverCordinate)
        {
            var currentRoverCordinate = roverCordinate switch
            {
                Cordinate.N => Cordinate.E,
                Cordinate.E => Cordinate.S,
                Cordinate.S => Cordinate.W,
                Cordinate.W => Cordinate.N,
                _ => throw new InvalidOperationException(),
            };
            return currentRoverCordinate;
        }

        public static Cordinate TurnLeft(Cordinate roverCordinate)
        {
            var currentRoverCordinate = roverCordinate switch
            {
                Cordinate.N => Cordinate.W,
                Cordinate.E => Cordinate.N,
                Cordinate.S => Cordinate.E,
                Cordinate.W => Cordinate.S,
                _ => throw new InvalidOperationException(),
            };
            return currentRoverCordinate;
        }
    }
}
