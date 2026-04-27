using System.Runtime.InteropServices;

namespace App;

internal class Program
{
    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);

    public static async Task Waiter()
    {
        var minuteInSec = 60;
        var secondInMilisec = 1000;
        for (var i = 0; i < minuteInSec; i++)
        {
            Console.Write($"\rPosition will be changed from: {minuteInSec - i}");
            await Task.Delay(secondInMilisec);
        }
    }

    private static async Task Main(string[] args)
    {
        var maxHeight = Console.LargestWindowHeight;
        var maxWidth = Console.LargestWindowWidth;
        var random = new Random();

        Console.WriteLine($"New cursor position    X:{0}    Y:{0}");
        SetCursorPos(0, 0);

        while (true)
        {
            var height = random.Next(0, maxHeight);
            var width = random.Next(0, maxWidth);

            await Waiter();

            Console.Clear();
            Console.WriteLine($"New cursor position    X:{width}    Y:{height}");
            SetCursorPos(width, height);
        }
    }
}