using MarsRover.Domain.Results;
using MarsRover.Domain.Services.Interfaces;
using MediatR;

namespace MarsRover.Domain.Commands
{
    public class MoveRoverCommand : IRequest<BaseResponseResult>
    {
        public readonly IRoverSquadService _roverSquadManager;
        public string Command { get; }
        public MoveRoverCommand(IRoverSquadService roverSquadManager, string command)
        {
            _roverSquadManager = roverSquadManager;

            Command = command;
        }
    }
}
