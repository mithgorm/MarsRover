using MarsRover.Core.RoversUseCases;
using MarsRover.Domain.Commands;
using MarsRover.Domain.Mars;
using MarsRover.Domain.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {

        static async Task Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args);
            await hostBuilder.RunConsoleAsync();
        }

        public class ConsoleApp : IHostedService
        {
            private readonly ILogger _logger;
            private readonly IMediator _mediator;
            public ConsoleApp(ILogger<ConsoleApp> logger, IMediator mediator)
            {
                _logger = logger;
                _mediator = mediator;
            }

            public async Task StartAsync(CancellationToken cancellationToken)
            {
                _logger.LogInformation("Starting application");
                var plateau = new Plateau();

                var roverSquadManager = new RoverSquadService(plateau);

                await _mediator.Send(new CreatePlateauCommand(plateau, "5 5"), cancellationToken);

                await _mediator.Send(new CreateRoverCommand(roverSquadManager, "1 2 N"), cancellationToken);
                await _mediator.Send(new MoveRoverCommand(roverSquadManager, "LMLMLMLMM"), cancellationToken);

                await _mediator.Send(new CreateRoverCommand(roverSquadManager, "3 3 E"), cancellationToken);
                await _mediator.Send(new MoveRoverCommand(roverSquadManager, "MMRMMRMRRM"), cancellationToken);

                foreach (var rover in roverSquadManager.ListRovers())
                {
                    Console.WriteLine(rover.Location());
                }

                Console.ReadLine();

            }

            public Task StopAsync(CancellationToken cancellationToken)
            {
                _logger.LogInformation("Stopped application");
                return null;
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
                     Host.CreateDefaultBuilder(args).ConfigureServices((hostingContext, services) =>
                     {
                         services.AddMediatR(Assembly.GetExecutingAssembly());
                         services.AddMediatR(AppDomain.CurrentDomain.Load("MarsRover.Core"));

                         services.AddSingleton<IHostedService, ConsoleApp>();
                     });
    }
}
