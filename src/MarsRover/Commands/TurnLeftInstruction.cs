namespace MarsRover.Commands;

public class TurnLeftInstruction : IInstruction
{
    private readonly IRover _rover;

    public TurnLeftInstruction(IRover rover)
    {
        _rover = rover;
    }

    public void Apply()
    {
        _rover.TurnLeft();
    }
}
