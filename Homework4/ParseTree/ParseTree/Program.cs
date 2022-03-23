using System;

namespace ParseTree
{
    class Program
    {
        private static void Main(string[] args)
        {

            Tree parseTree = new Tree("+ 1 2");
            parseTree.Print();
            Console.WriteLine(parseTree.Calculate());

        }
    }
}