using MarsRover.Enums;
using MarsRover.Exceptions;

namespace MarsRover.Commands;

public static class InstructionFactory
{
    public static IInstruction Create(IRover rover, Instruction instruction) => instruction switch
    {
        Instruction.L => new TurnLeftInstruction(rover),
        Instruction.R => new TurnRightInstruction(rover),
        Instruction.M => new MoveForwardInstruction(rover),
        _ => throw new InvalidInstructionException()
    };
}
