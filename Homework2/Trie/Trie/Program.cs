namespace Trie;

using System;

class Program
{
    private static void Main(string[] args)
    {
        var trie = new Trie();

        Console.WriteLine("Command for trie:");
        Console.WriteLine("Add - adds string to trie");
        Console.WriteLine("Contain - checks whether this string is contained in trie");
        Console.WriteLine("Remove - removes string from trie");
        Console.WriteLine("Prefix - counts how many words starts with given prefix");
        Console.WriteLine("End - completes the program");

        while (true)
        {
            Console.Write("Enter your command: ");
            var command = Console.ReadLine();
            string? inputString;
            switch (command)
            {
                case "Add":
                    Console.Write("Enter string to add to trie: ");
                    inputString = Console.ReadLine();
                    if (inputString == null)
                    {
                        Console.WriteLine("String is null");
                        return;
                    }
                    Console.WriteLine(trie.Add(inputString) ? "String was added to trie" : "Such string already exists in trie");
                    break;
                case "Contain":
                    Console.Write("Enter string to check if it is contained in trie: ");
                    inputString = Console.ReadLine();
                    if (inputString == null)
                    {
                        Console.WriteLine("String is null");
                        return;
                    }
                    Console.WriteLine(trie.Contains(inputString) ? "String is contained in trie" : "String is not contained in trie");
                    break;
                case "Remove":
                    Console.Write("Enter string to remove from trie: ");
                    inputString = Console.ReadLine();
                    if (inputString == null)
                    {
                        Console.WriteLine("String is null");
                        return;
                    }
                    Console.WriteLine(trie.Remove(inputString) ? "String was removed from trie" : "There is no such string in trie");
                    break;
                case "Prefix":
                    Console.Write("Enter prefix to count how many words starts with it: ");
                    inputString = Console.ReadLine();
                    if (inputString == null)
                    {
                        Console.WriteLine("String is null");
                        return;
                    }
                    Console.WriteLine(trie.HowManyStartsWithPrefix(inputString));
                    break;
                case "End":
                    return;
                default:
                    Console.WriteLine("Incorrect command");
                    break;
            }
        }

    }
}