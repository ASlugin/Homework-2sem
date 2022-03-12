using System;

namespace Trie
{
    class Program
    {
        private static void Main(string[] args)
        {

            Trie trie = new Trie();

            Console.Write(trie.Add("he"));
            Console.WriteLine(" " + trie.Size);

            Console.Write(trie.Add("his"));
            Console.WriteLine(" " + trie.Size);

            Console.Write(trie.Add("she"));
            Console.WriteLine(" " + trie.Size);

            Console.Write(trie.Add("hers"));
            Console.WriteLine(" " + trie.Size);

            /*
            Console.Write(trie.Remove("she"));
            Console.WriteLine(" " + trie.Size);
            Console.Write(trie.Remove("his"));
            Console.WriteLine(" " + trie.Size);
            Console.Write(trie.Remove("hers"));
            Console.WriteLine(" " + trie.Size);
            Console.Write(trie.Remove("he"));
            Console.WriteLine(" " + trie.Size);
            Console.Write(trie.Remove("his"));
            Console.WriteLine(" " + trie.Size);
            */

            Console.WriteLine(trie.HowManyStartsWithPrefix(""));



        }
    }
}