using MarsRover.Domain.Commands;
using MarsRover.Domain.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Core.PlateauUseCases
{
    public class CreatePlateauHandler : IRequestHandler<CreatePlateauCommand, BaseResponseResult>
    {
        private readonly ILogger<CreatePlateauHandler> _logger;
        public CreatePlateauHandler(ILogger<CreatePlateauHandler> logger)
        {
            _logger = logger;
        }

        public async Task<BaseResponseResult> Handle(CreatePlateauCommand command, CancellationToken cancellationToken)
        {

            BaseResponseResult response = new BaseResponseResult();

            try
            {
                ParseCommand(command.ConsoleCommand, out var width, out var height);
                command.Plateau.Define(width, height);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Errors.Add("An error occurred while create Plateau.");
            }

            return response;
        }

        private void ParseCommand(string command, out int width, out int height)
        {
            var splitCommand = command.Split(' ');

            width = int.Parse(splitCommand[0]);

            height = int.Parse(splitCommand[1]);
        }
    }
}
