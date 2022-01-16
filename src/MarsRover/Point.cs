namespace MarsRover;

public record Point(int X, int Y)
{
    public bool IsWithinBounds(Point min, Point max)
        => max.X >= X && max.Y >= Y && min.X <= X && min.Y <= Y;
}