using System;
namespace SnakeGame;

class Program
{
    static void Main(string[] args)
    {
        bool finished = false;
        Canvas canvas = new Canvas();
        Snake snake = new Snake();
        Food food = new Food();
        HighScore highScore = new HighScore();

        Console.WriteLine("\t \t \t \t PRESS ENTER");
        Console.Read();

        while(!finished)
        {
            try
            {
            canvas.drawCanvas();
            Console.SetCursorPosition(100, 5);
            Console.WriteLine("SCORE: {0}", snake.score);
            snake.Input();
            Console.SetCursorPosition(120, 5);
            Console.WriteLine("HIGH SCORE: {0}", highScore.GetHighScore());
            food.drawFood();
            snake.drawSnake();
            snake.moveSnake();
            snake.eat(food.foodLocation(), food);
            if(snake.score > highScore.GetHighScore()){
                highScore.UpdateHighScore(snake.score);
            }
            snake.isDead();
            snake.hitWall(canvas);
            }
            catch(SnakeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);

                Console.WriteLine("Restart (y/n)");
                char c = char.Parse(Console.ReadLine());

                switch(c)
                {
                    case 'y':
                    snake.x = 20;
                    snake.y = 20;
                    snake.score = 0;
                    snake.snakeBody.RemoveRange(0, snake.snakeBody.Count - 1);

                    break;

                    case 'n': 
                    finished = true;
                    break;

                }
            }
        }
    }
}