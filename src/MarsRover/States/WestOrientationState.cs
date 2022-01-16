using MarsRover.Enums;

namespace MarsRover.States;

public record WestOrientationState(Point Position) : OrientationState(Position)
{
    public override Orientation Orientation => Orientation.W;

    public override OrientationState MoveForward()
        => new WestOrientationState(new Point(Position.X - 1, Position.Y));

    public override OrientationState TurnLeft()
        => new SouthOrientationState(Position);

    public override OrientationState TurnRight()
        => new NorthOrientationState(Position);
}
