using MarsRover.Domain.Commands;
using MarsRover.Domain.Enums;
using MarsRover.Domain.Results;
using MarsRover.Domain.Rover.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Core.RoversUseCases
{
    public class MoveRoverHandler : IRequestHandler<MoveRoverCommand, BaseResponseResult>
    {
        private readonly ILogger<MoveRoverHandler> _logger;
        public MoveRoverHandler(ILogger<MoveRoverHandler> logger)
        {
            _logger = logger;
        }
        public async Task<BaseResponseResult> Handle(MoveRoverCommand command, CancellationToken cancellationToken)
        {
            BaseResponseResult response = new BaseResponseResult();

            try
            {
                var activeRover = command._roverSquadManager.ActiveRover();

                MoveRover(activeRover, command.Command);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Errors.Add("An error occurred while move Rover.");
            }

            return response;
        }



        private void MoveRover(IRover rover, string command)
        {
            foreach (var movement in command)
            {
                if (!IsValidMovement(movement.ToString()))
                {
                    throw new ArgumentException($"Invalid Movement {movement} passed in the command");
                }

                rover.Move((Movement)Enum.Parse(typeof(Movement), movement.ToString()));
            }
        }

        private bool IsValidMovement(string movement)
        {
            return Enum.TryParse(movement, out Movement _);
        }
    }
}
