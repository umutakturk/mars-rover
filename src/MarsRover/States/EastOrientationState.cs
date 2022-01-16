using MarsRover.Enums;

namespace MarsRover.States;

public record EastOrientationState(Point Position) : OrientationState(Position)
{
    public override Orientation Orientation => Orientation.E;

    public override OrientationState MoveForward()
        => new EastOrientationState(new Point(Position.X + 1, Position.Y));

    public override OrientationState TurnLeft()
        => new NorthOrientationState(Position);

    public override OrientationState TurnRight()
        => new SouthOrientationState(Position);
}
