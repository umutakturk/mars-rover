using MarsRover.Exceptions;
using Xunit;

namespace MarsRover.Tests;

public class MarsRoverTests
{
    [Theory]
    [InlineData("5 5", "1 2 N", "LMLMLMLMM", "1 3 N")]
    [InlineData("5 5", "3 3 E", "MMRMMRMRRM", "5 1 E")]
    [InlineData("5 5", "4 2 W", "", "4 2 W")]
    public void RoverShouldNavigatesExpectedDestination(string landingArea, string position, string movements, string expected)
    {
        ControlCenter controlCenter = new();
        controlCenter.SetLandingArea(landingArea);
        controlCenter.SendCommand(position, movements);
        controlCenter.NavigateSquad();

        Assert.Equal(expected, controlCenter.CurrentRover?.ToString());
    }

    [Fact]
    public void SendCommandMethodShouldThrowsInvalidInstructionException()
    {
        Assert.Throws<InvalidInstructionException>(() =>
        {
            ControlCenter controlCenter = new();
            controlCenter.SetLandingArea("5 5");
            controlCenter.SendCommand("3 3 E", "MLMWLMRRM");
            controlCenter.NavigateSquad();
        });
    }

    [Fact]
    public void NavigateSquadMethodShouldThrowsOutOfBoundsException()
    {
        Assert.Throws<OutOfBoundsException>(() =>
        {
            ControlCenter controlCenter = new();
            controlCenter.SetLandingArea("5 5");
            controlCenter.SendCommand("3 3 E", "MMRMMRMRRMMMMMMMM");
            controlCenter.NavigateSquad();
        });
    }

    [Fact]
    public void NavigateSquadMethodShouldThrowsCollisionException()
    {
        Assert.Throws<CollisionException>(() =>
        {
            ControlCenter controlCenter = new();
            controlCenter.SetLandingArea("5 5");
            controlCenter.SendCommand("1 2 E", "M");
            controlCenter.SendCommand("1 2 E", "M");
            controlCenter.NavigateSquad();
        });
    }

    [Fact]
    public void SetLandingAreaMethodShouldThrowsInvalidInputException()
    {
        Assert.Throws<InvalidInputException>(() =>
        {
            ControlCenter controlCenter = new();
            controlCenter.SetLandingArea("5 ");
        });
    }
}
