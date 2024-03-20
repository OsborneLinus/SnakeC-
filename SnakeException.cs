using System;

namespace SnakeGame;

public class SnakeException : ApplicationException
{
    public SnakeException(string message) : base(message)
    {

    }
}