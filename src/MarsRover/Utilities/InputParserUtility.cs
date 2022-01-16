using System.Text.RegularExpressions;
using MarsRover.Enums;
using MarsRover.Exceptions;

namespace MarsRover.Utilities;

public static class InputParserUtility
{
    public static Point ParseLandingArea(string input)
    {
        if (!Regex.IsMatch(input.Trim(), "^\\d+ \\d+$"))
            throw new InvalidInputException();

        var values = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var width = int.Parse(values[0]);
        var height = int.Parse(values[1]);

        return new Point(width, height);
    }

    public static (Point Point, Orientation Orientation) ParsePosition(string input)
    {
        if (!Regex.IsMatch(input.Trim(), "^\\d+ \\d+ (N|E|S|W)$"))
            throw new InvalidInputException();

        var values = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var pointX = int.Parse(values[0]);
        var pointY = int.Parse(values[1]);
        var orientation = Enum.TryParse<Orientation>(values[2], out var result) ? result : Orientation.Undefined;

        return (new Point(pointX, pointY), orientation);
    }

    public static IEnumerable<Instruction> ParseMovements(string movements)
    {
        return movements.Select(s => Enum.TryParse<Instruction>(s.ToString(), out var result) ? result : Instruction.Undefined);
    }
}
