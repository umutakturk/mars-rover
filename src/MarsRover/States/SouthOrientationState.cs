using MarsRover.Enums;

namespace MarsRover.States;

public record SouthOrientationState(Point Position) : OrientationState(Position)
{
    public override Orientation Orientation => Orientation.S;

    public override OrientationState MoveForward()
        => new SouthOrientationState(new Point(Position.X, Position.Y - 1));

    public override OrientationState TurnLeft()
        => new EastOrientationState(Position);

    public override OrientationState TurnRight()
        => new WestOrientationState(Position);
}
