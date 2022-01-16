using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.Console;

internal static class Program
{
    private static void Main(string[] args)
    {
        try
        {
            var services = new ServiceCollection()
                .AddSingleton<IControlCenter, ControlCenter>()
                .BuildServiceProvider();

            var inputs = File.ReadAllLines("input.txt");

            var controlCenter = services.GetRequiredService<IControlCenter>();
            controlCenter.SetLandingArea(inputs[0]);

            for (var i = 1; i <= inputs.Length - 1; i += 2)
            {
                try
                {
                    controlCenter.SendCommand(inputs[i], inputs[i + 1]);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine($"Rover could not be deployed. The input file has invalid command. Line {i}-{i + 1}");
                    System.Console.WriteLine(e.Message);
                }
            }

            controlCenter.NavigateSquad();

            foreach (var (rover, _) in controlCenter.Squad)
            {
                System.Console.WriteLine(rover.ToString());
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
    }
}
