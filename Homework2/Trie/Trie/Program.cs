using System;

namespace Trie
{
    class Program
    {
        private static void Main(string[] args)
        {

            Trie trie = new Trie();
            Console.WriteLine(trie.Size);

            var result = trie.Add("ab");
            Console.WriteLine(result);
            Console.WriteLine(trie.Size);

            result = trie.Add("a");
            Console.WriteLine(result);
            Console.WriteLine(trie.Size);

            result = trie.Add("cde");
            Console.WriteLine(result);
            Console.WriteLine(trie.Size);

            result = trie.Add("cd");
            Console.WriteLine(result);
            Console.WriteLine(trie.Size);

            var search = trie.Contains("de");
            Console.WriteLine(search);

            Console.WriteLine(trie.Size);
        }
    }
}