using MarsRover.Enums;

namespace MarsRover.States;

public abstract record OrientationState
{
    public Point Position { get; }
    public abstract Orientation Orientation { get; }

    protected OrientationState(Point position)
    {
        Position = position;
    }

    public abstract OrientationState MoveForward();
    public abstract OrientationState TurnLeft();
    public abstract OrientationState TurnRight();
}
