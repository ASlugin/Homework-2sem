using System;
using System.Collections.Generic;

namespace Trie
{
    class Trie
    {
        public Trie()
        {
            this.root = new Element();
        }

        private class Element
        {
            public Element()
            {
                this.NextElements = new Dictionary<char, Element>();
                this.Terminal = false;
            }
            public Dictionary<char, Element> NextElements;
            public bool Terminal;
        }

        public int Size { get; private set; } = 0;

        private Element root;

        /// <summary>
        /// Adds a string to trie
        /// </summary>
        /// <param name="element">String to add to trie</param>
        /// <returns>True if there has not been such a string yet</returns>
        public bool Add(string element)
        {
            var currentElement = root;
            for (int i = 0; i < element.Length; i++)
            {
                if (currentElement.NextElements.ContainsKey(element[i]))
                {
                    if (i == element.Length - 1)
                    {
                        if (currentElement.NextElements[element[i]].Terminal == false)
                        {
                            Size++;
                            currentElement.NextElements[element[i]].Terminal = true;
                            return true;
                        }
                        return false;
                    }
                    currentElement = currentElement.NextElements[element[i]];
                }
                else
                {
                    currentElement.NextElements.Add(element[i], new Element());
                    if (i == element.Length - 1)
                    {
                        currentElement.NextElements[element[i]].Terminal = true;
                        Size++;
                        return true;
                    }
                    currentElement = currentElement.NextElements[element[i]];
                }
            }
            return false;
        }

        /// <summary>
        /// Checks whether a string is contained in trie
        /// </summary>
        /// <param name="element">String to looking for in trie</param>
        /// <returns>True if such string is contained in trie, else returns false</returns>
        public bool Contains(string element)
        {
            var currentElement = root;
            for (int i = 0; i < element.Length; ++i)
            {
                if (currentElement.NextElements.ContainsKey(element[i]))
                {
                    currentElement = currentElement.NextElements[element[i]];
                    if (i == element.Length - 1 && currentElement.Terminal == true)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool Remove(string element)
        {
            return true;
        }
        public int HowManyStartsWithPrefix(String prefix)
        {
            return 0;
        }


    }
}
