using MarsRover.Domain.Commands;
using MarsRover.Domain.Enums;
using MarsRover.Domain.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Core.RoversUseCases
{
    public class CreateRoverHandler : IRequestHandler<CreateRoverCommand, BaseResponseResult>
    {
        private readonly ILogger<CreateRoverHandler> _logger;
        public CreateRoverHandler(ILogger<CreateRoverHandler> logger)
        {
            _logger = logger;
        }
        public async Task<BaseResponseResult> Handle(CreateRoverCommand command, CancellationToken cancellationToken)
        {
            BaseResponseResult response = new BaseResponseResult();

            try
            {
                ParseCommand(command.Command, out var x, out var y, out var direction);
                command.RoverSquadManager.DeployRover(x, y, direction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Errors.Add("An error occurred while create Rover.");
            }

            return response;
        }

        private void ParseCommand(string command, out int x, out int y, out Direction direction)
        {
            var splitCommand = command.Split(' ');

            x = int.Parse(splitCommand[0]);

            y = int.Parse(splitCommand[1]);

            if (!Enum.TryParse(splitCommand[2], out direction))
            {
                throw new ArgumentException($"Invalid Direction {splitCommand[2]} passed in the command");
            }

        }
    }
}
