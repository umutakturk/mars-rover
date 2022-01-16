using MarsRover.Enums;

namespace MarsRover.States;

public record NorthOrientationState(Point Position) : OrientationState(Position)
{
    public override Orientation Orientation => Orientation.N;

    public override OrientationState MoveForward()
        => new NorthOrientationState(new Point(Position.X, Position.Y + 1));

    public override OrientationState TurnLeft()
        => new WestOrientationState(Position);

    public override OrientationState TurnRight()
        => new EastOrientationState(Position);
}
