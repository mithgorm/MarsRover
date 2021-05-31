using MarsRover.Domain.Enums;

namespace MarsRover.Domain.Rover.Interfaces
{
    public interface IRover
    {
        void Move(Movement movement);
        string Location();
    }
}
