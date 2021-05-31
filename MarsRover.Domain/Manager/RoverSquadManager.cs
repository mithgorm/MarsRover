using MarsRover.Domain.Enums;
using MarsRover.Domain.Mars.Interfaces;
using MarsRover.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace MarsRover.Domain.Services
{
    public class RoverSquadService : IRoverSquadService
    {
        private List<Rover.Rover> _rovers;

        private Rover.Rover _activeRover;

        private readonly IPlateau _plateau;

        public RoverSquadService(IPlateau plateau)
        {
            _rovers = new List<Rover.Rover>();

            _plateau = plateau;
        }

        public void DeployRover(int x, int y, Direction direction)
        {
            if (IsValidDeploymentLocation(x, y))
            {
                var rover = new Rover.Rover(_plateau, x, y, direction);

                _rovers.Add(rover);

                _activeRover = rover;
            }
            else
            {
                throw new ArgumentException("Rover location is out of bounds.");
            }
        }

        public Rover.Rover ActiveRover()
        {
            return _activeRover;
        }

        public int CountOfRovers()
        {
            return _rovers.Count;
        }

        public List<Rover.Rover> ListRovers()
        {
            return _rovers;
        }

        private bool IsValidDeploymentLocation(int x, int y)
        {
            return x >= 0 && x <= _plateau.Width() && y >= 0 && y <= _plateau.Height();
        }
    }
}
