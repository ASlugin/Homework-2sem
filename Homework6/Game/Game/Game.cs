namespace Game;

using System;
using System.IO;

public class Game
{
    private (int, int) position;

    private char[,] map;
    private int width = 0;
    private int height  = 0;

    private int points = 0;
    private (int, int) positionPoints;

    public Game(string path)
    {
        string[] mapFromFile = File.ReadAllLines(path);
        int maxWidth = 0;
        foreach(var line in mapFromFile)
        {
            maxWidth = Math.Max(maxWidth, line.Length);
        }
        map = new char[maxWidth, mapFromFile.Length];
        width = maxWidth;
        height = mapFromFile.Length;

        for (int y = 0; y < mapFromFile.Length; y++)
        {
            for (int x = 0; x < mapFromFile[y].Length; x++)
            {
                switch (mapFromFile[y][x])
                {
                    case '#':
                        map[x, y] = '#';
                        Console.SetCursorPosition(x, y);
                        Console.Write('#');
                        break;
                    case '@':
                        position = (x, y);
                        Console.SetCursorPosition(x, y);
                        Console.Write('@');
                        break;
                    case '$':
                        map[x, y] = '$';
                        Console.SetCursorPosition(x, y);
                        Console.Write('$');
                        break;
                    default:
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                        break;
                }
            }
        }
        Console.SetCursorPosition(0, height);
        Console.Write("Your points: ");
        positionPoints = Console.GetCursorPosition();
        Console.WriteLine(points);

        Console.WriteLine();
        Console.WriteLine("You are @. To move, use the arrows");
        Console.WriteLine("Don't crash into #");
        Console.WriteLine("Try to collect as many $ as you can");
        Console.WriteLine("To exit, type Escape");

    }

    /// <summary>
    /// Moves player to left
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void OnLeft(object? sender, EventArgs args)
    {
        ChangePosition(-1, 0);
    }

    /// <summary>
    /// Moves player to right
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void OnRight(object? sender, EventArgs args)
    {
        ChangePosition(1, 0);
    }

    /// <summary>
    /// Moves player up
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void OnUp(object? sender, EventArgs args)
    {
        ChangePosition(0, -1);
    }

    /// <summary>
    /// Moves player down
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void OnDown(object? sender, EventArgs args)
    {
        ChangePosition(0, 1);
    }

    /// <summary>
    /// Ends game and prints final sum of points
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void Escape(object? sender, EventArgs args)
    {
        Console.Clear();
        Console.WriteLine("Game over!");
        Console.WriteLine($"Your points: {points}");
        Environment.Exit(0);
    }

    private void IncrementPointsAndChange()
    {
        ++points;
        Console.SetCursorPosition(positionPoints.Item1, positionPoints.Item2);
        Console.Write("     ");
        Console.SetCursorPosition(positionPoints.Item1, positionPoints.Item2);
        Console.Write(points);
    }

    private void CreateNewGoal()
    {
        var random = new Random();
        int newX = random.Next(1, width - 1);
        int newY = random.Next(1, height - 1);
        while (map[newX, newY] != '\0')
        {
            newX = random.Next(1, width - 1);
            newY = random.Next(1, height - 1);
        }
        map[newX, newY] = '$';
        Console.SetCursorPosition(newX, newY);
        Console.Write('$');
    }

    private void ChangePosition(int deltaX, int deltaY)
    {
        if (position.Item1 + deltaX < 0 || position.Item1 + deltaX >= width 
            || position.Item2 + deltaY < 0 || position.Item2 + deltaY >= height
            || map[position.Item1 + deltaX, position.Item2 + deltaY] == '#')
        {
            Console.Clear();
            Console.WriteLine("You died. Game over!");
            Console.WriteLine($"Your points: {points}");
            Environment.Exit(0);
        }
        if (map[position.Item1 + deltaX, position.Item2 + deltaY] == '$')
        {
            IncrementPointsAndChange();
            map[position.Item1 + deltaX, position.Item2 + deltaY] = '\0';
            CreateNewGoal();
        }
        Console.SetCursorPosition(position.Item1, position.Item2);
        Console.Write(' ');
        position = (position.Item1 + deltaX, position.Item2 + deltaY);
        Console.SetCursorPosition(position.Item1, position.Item2);
        Console.Write('@');
    }
}