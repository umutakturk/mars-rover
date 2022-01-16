using MarsRover.Enums;
using MarsRover.Exceptions;

namespace MarsRover.States;

public static class OrientationStateFactory
{
    public static OrientationState Create(Point position, Orientation orientation) => orientation switch
    {
        Orientation.N => new NorthOrientationState(position),
        Orientation.S => new SouthOrientationState(position),
        Orientation.E => new EastOrientationState(position),
        Orientation.W => new WestOrientationState(position),
        _ => throw new InvalidOrientationStateException(),
    };
}
