using MarsRover.Enums;
using MarsRover.States;

namespace MarsRover;

public class Rover : IRover
{
    private OrientationState _state;

    public Rover(Point position, Orientation orientation)
    {
        Id = Guid.NewGuid();
        _state = OrientationStateFactory.Create(position, orientation);
    }

    public Guid Id { get; }

    public Point Position => _state.Position;

    public void MoveForward()
        => _state = _state.MoveForward();

    public void TurnLeft()
        => _state = _state.TurnLeft();

    public void TurnRight()
        => _state = _state.TurnRight();

    public override string ToString()
        => $"{_state.Position.X} {_state.Position.Y} {_state.Orientation}";
}
