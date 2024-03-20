using System; 
using System.Collections.Generic;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
namespace SnakeGame;

class Snake
{
    ConsoleKeyInfo KeyInfo = new ConsoleKeyInfo();
    char key = 'w';
    char dir = 'u';

    public List<Position> snakeBody {get; set;}
    public int x {get; set;}
    public int y {get; set;}
    public int score {get; set;}

    public Snake()
    {
        x = 20;
        y = 20;
        score = 0;

        snakeBody = new List<Position>();
        snakeBody.Add(new Position(x, y));
    }

    public void drawSnake()
    {
        foreach(Position pos in snakeBody)
        {
        Console.SetCursorPosition(pos.x, pos.y);
        Console.Write("▊");

        }
    }

    public void Input()
    {
        if(Console.KeyAvailable)
        {
            KeyInfo = Console.ReadKey(true);
        }
    }

    public void direction()
    {
        if(KeyInfo.Key == ConsoleKey.UpArrow && dir != 'd')
        {
            dir = 'u';
        } else if (KeyInfo.Key == ConsoleKey.DownArrow && dir != 'u')
        {
            dir = 'd';
        } else if (KeyInfo.Key == ConsoleKey.RightArrow && dir != 'l')
        {
            dir = 'r';
        } else if (KeyInfo.Key == ConsoleKey.LeftArrow && dir != 'r')
        {
            dir = 'l';
        }
    }

    public void moveSnake()
    {
        direction();
        if(dir == 'u')
        {
            y--;
        }
        else if (dir == 'd')
        {
            y++;
        } 
        else if (dir == 'r')
        {
            x++;
        }
        else if (dir == 'l')
        {
            x--;
        }
        if(dir != '\0')
        {
        snakeBody.Add(new Position(x, y));
        snakeBody.RemoveAt(0);
        Thread.Sleep(100);

        }
    }
    public void eat(Position food, Food f)
    {
        Position head = snakeBody[snakeBody.Count -1];
        if(head.x == food.x && head.y == food.y)
        {
            snakeBody.Add(new Position(x, y));
            f.foodNewLocation();
            score++;
        }
    }
    public void isDead()
    {
        Position head = snakeBody[snakeBody.Count - 1];
        for(int i = 0; i < snakeBody.Count -2; i++)
        {
            Position sb = snakeBody[i];

            if(head.x == sb.x && head.y == sb.y)
            {
                throw new SnakeException("You Lost!");
            }
        }
    }

    public void hitWall(Canvas canvas)
    {
        Position head = snakeBody[snakeBody.Count - 1];
        if(head.x >= canvas.Width || head.x <= 0 || head.y >= canvas.Height || head.y <= 0)
        {
            throw new SnakeException("You Lost!");
        }
    }
}