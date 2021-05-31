using MarsRover.Domain.Enums;
using System.Collections.Generic;

namespace MarsRover.Domain.Services.Interfaces
{
    public interface IRoverSquadService
    {
        void DeployRover(int x, int y, Direction direction);
        Rover.Rover ActiveRover();
        int CountOfRovers();
        List<Rover.Rover> ListRovers();
    }
}
