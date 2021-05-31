using MarsRover.Domain.Mars.Interfaces;
using MarsRover.Domain.Results;
using MediatR;

namespace MarsRover.Domain.Commands
{
    public class CreatePlateauCommand : IRequest<BaseResponseResult>
    {
        public IPlateau Plateau { get; set; }

        public string ConsoleCommand { get; set; }

        public CreatePlateauCommand(IPlateau plateau, string command)
        {
            Plateau = plateau;
            ConsoleCommand = command;
        }
    }
}
