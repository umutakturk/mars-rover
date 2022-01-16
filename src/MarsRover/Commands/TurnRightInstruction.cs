namespace MarsRover.Commands;

public class TurnRightInstruction : IInstruction
{
    private readonly IRover _rover;

    public TurnRightInstruction(IRover rover)
    {
        _rover = rover;
    }

    public void Apply()
    {
        _rover.TurnRight();
    }
}