using System;
using System.Runtime.InteropServices;

namespace SnakeGame;

public class Food
{
    public Position foodPos = new Position();

    Random rnd = new Random();
    Canvas canvas = new Canvas();

    public Food()
    {
        foodPos.y = rnd.Next(5, canvas.Width - 1 );
        foodPos.x = rnd.Next(5, canvas.Height - 1);
    }

    public void drawFood()
    {
        Console.SetCursorPosition(foodPos.x, foodPos.y);
        Console.Write("F");
    }

    public Position foodLocation()
    {
        return foodPos;
    }
    public void foodNewLocation()
    {
        foodPos.x = rnd.Next(5, canvas.Width - 1);
        foodPos.y = rnd.Next(5, canvas.Height - 1);
    }
}