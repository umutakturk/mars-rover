namespace MarsRover;

public record LandingArea
{
    public Point MinBounds { get; }
    public Point MaxBounds { get; }

    public LandingArea(int width, int height)
    {
        MinBounds = new Point(0, 0);
        MaxBounds = new Point(width, height);
    }
}
