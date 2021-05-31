using MarsRover.Domain.Results;
using MarsRover.Domain.Services.Interfaces;
using MediatR;

namespace MarsRover.Domain.Commands
{
    public class CreateRoverCommand : IRequest<BaseResponseResult>
    {
        public IRoverSquadService RoverSquadManager { get; set; }

        public string Command { get; set; }

        public CreateRoverCommand(IRoverSquadService roverSquadManager, string command)
        {
            RoverSquadManager = roverSquadManager;

            Command = command;
        }




    }
}
