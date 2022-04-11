namespace Game;

using System;
using System.IO;
public class Game
{
    private (int, int) position { get; set; }

    private char[,] map;
    private int width { get; set; } = 0;
    private int height { get; set; } = 0;

    private int points { get; set; } = 0;
    private (int, int) positionPoints { get; set; }

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
                        Console.CursorLeft = x;
                        Console.CursorTop = y;
                        Console.Write('#');
                        break;
                    case '@':
                        position = (x, y);
                        Console.CursorLeft = x;
                        Console.CursorTop = y;
                        Console.Write('@');
                        break;
                    case '$':
                        map[x, y] = '$';
                        Console.CursorLeft = x;
                        Console.CursorTop = y;
                        Console.Write('$');
                        break;
                    default:
                        Console.CursorLeft = x;
                        Console.CursorTop = y;
                        Console.Write(' ');
                        break;
                }
            }
        }
        Console.CursorLeft = 0;
        Console.CursorTop = height;
        Console.Write("Your points: ");
        positionPoints = Console.GetCursorPosition();
        Console.Write(points);

    }

    public void OnLeft(object? sender, EventArgs args)
    {
        ChangePosition(-1, 0);
    }
    public void OnRight(object? sender, EventArgs args)
    {
        ChangePosition(1, 0);
    }
    public void OnUp(object? sender, EventArgs args)
    {
        ChangePosition(0, -1);
    }
    public void OnDown(object? sender, EventArgs args)
    {
        ChangePosition(0, 1);
    }
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
        Console.CursorLeft = positionPoints.Item1;
        Console.CursorTop = positionPoints.Item2;
        Console.Write("    ");
        Console.CursorLeft = positionPoints.Item1;
        Console.CursorTop = positionPoints.Item2;
        Console.Write(points);
    }

    private void CreateNewGoal()
    {
        Random random = new Random();
        int newX = random.Next(1, width - 1);
        int newY = random.Next(1, height - 1);
        while (map[newX, newY] == '#' || map[newX, newY] == '@')
        {
            newX = random.Next(1, width - 1);
            newY = random.Next(1, height - 1);
        }
        map[newX, newY] = '$';
        Console.CursorLeft = newX;
        Console.CursorTop = newY;
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
        Console.CursorLeft = position.Item1;
        Console.CursorTop = position.Item2;
        Console.Write(' ');
        position = (position.Item1 + deltaX, position.Item2 + deltaY);
        Console.CursorLeft = position.Item1;
        Console.CursorTop = position.Item2;
        Console.Write('@');
    }
}