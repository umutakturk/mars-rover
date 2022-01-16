namespace MarsRover.Commands;

public class MoveForwardInstruction : IInstruction
{
    private readonly IRover _rover;

    public MoveForwardInstruction(IRover rover)
    {
        _rover = rover;
    }

    public void Apply()
    {
        _rover.MoveForward();
    }
}
