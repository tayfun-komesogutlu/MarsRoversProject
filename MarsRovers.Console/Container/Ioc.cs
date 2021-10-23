using MarsRovers.Business.Command;
using MarsRovers.Business.Dto;
using MarsRovers.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRovers.Console.Container
{
    public class Ioc
    {
        public static ServiceProvider Configure()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<ICommand, TurnLeft>();
            services.AddTransient<ICommand, TurnRight>();
            services.AddTransient<ICommand, Move>();
            services.AddTransient<IRoverCommand, RoverCommand>();
            services.AddTransient<IRoverCordinate, RoverCordinate>();
            services.AddTransient<IRover, Rover>();
            services.AddTransient<IPlateau, Plateau>();

            return services.BuildServiceProvider();
        }
    }
}
