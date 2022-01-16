using MarsRover.Commands;
using MarsRover.Exceptions;
using MarsRover.Utilities;

namespace MarsRover;

public class ControlCenter : IControlCenter
{
    private LandingArea? _landingArea;

    public ControlCenter()
    {
        Squad = new();
    }

    public IRover? CurrentRover { get; private set; }

    public List<(IRover Rover, List<IInstruction> Instructions)> Squad { get; }

    public void SetLandingArea(string bounds)
    {
        var point = InputParserUtility.ParseLandingArea(bounds);
        _landingArea = new LandingArea(point.X, point.Y);
    }

    public void SendCommand(string position, string movements)
    {
        var (point, orientation) = InputParserUtility.ParsePosition(position);
        Rover rover = new(point, orientation);

        List<IInstruction> instructionList = new();
        var instructions = InputParserUtility.ParseMovements(movements);

        foreach (var instruction in instructions)
        {
            instructionList.Add(InstructionFactory.Create(rover, instruction));
        }

        CurrentRover = rover;
        Squad.Add((rover, instructionList));
    }

    public void NavigateSquad()
    {
        foreach (var (rover, instructions) in Squad)
        {
            foreach (var instruction in instructions)
            {
                instruction.Apply();

                if (!rover.Position.IsWithinBounds(_landingArea!.MinBounds, _landingArea!.MaxBounds))
                {
                    throw new OutOfBoundsException();
                }

                if (Squad.Any(p => !p.Rover.Id.Equals(rover.Id) && p.Rover.Position.Equals(rover.Position)))
                {
                    throw new CollisionException();
                }
            }
        }
    }
}
