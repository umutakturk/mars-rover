namespace MarsRover;

public interface IRover
{
    Guid Id { get; }
    Point Position { get; }
    void MoveForward();
    void TurnLeft();
    void TurnRight();
}
