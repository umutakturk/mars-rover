using MarsRover.Commands;

namespace MarsRover;

public interface IControlCenter
{
    IRover? CurrentRover { get; }
    List<(IRover Rover, List<IInstruction> Instructions)> Squad { get; }
    void SetLandingArea(string bounds);
    void SendCommand(string position, string movements);
    void NavigateSquad();
}