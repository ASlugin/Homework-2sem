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

        private Element root;
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

        /// <summary>
        /// Amount of word in trie
        /// </summary>
        public int Size { get; private set; } = 0;

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

        /// <summary>
        /// Removes given string from trie
        /// </summary>
        /// <param name="element">String to remove from trie</param>
        /// <returns>True if such string was in trie, else returns false</returns>
        public bool Remove(string element)
        {
            bool removeThisElement = false;
            return RemoveRecursive(root, element, ref removeThisElement);
        }

        private bool RemoveRecursive(Element currentElement, string element, ref bool removeThisElement)
        {
            if (element.Length == 0)
            {
                if (currentElement.Terminal == true)
                {
                    Size--;
                    currentElement.Terminal = false;
                    removeThisElement = currentElement.NextElements.Count == 0 ? true : false;
                    return true;
                }
                return false;
            }

            if (currentElement.NextElements.ContainsKey(element[0]))
            {
                if (!RemoveRecursive(currentElement.NextElements[element[0]],element.Substring(1), ref removeThisElement))
                {
                    return false;
                }
                if (removeThisElement)
                {
                    currentElement.NextElements.Remove(element[0]);
                    removeThisElement = currentElement.NextElements.Count == 0 && currentElement.Terminal == false ? true : false;
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Counts how many words starts with a given prefix
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns>Amount word which starts with given prefix</returns>
        public int HowManyStartsWithPrefix(string prefix)
        {
            var currentElement = root;
            for (var i = 0; i < prefix.Length; ++i)
            {
                if (!currentElement.NextElements.ContainsKey(prefix[i]))
                {
                    return 0;
                }
                currentElement = currentElement.NextElements[prefix[i]];
            }
            return terminalElementCounter(currentElement);
        }

        private int terminalElementCounter(Element currentElement)
        {
            int result = currentElement.Terminal ? 1 : 0;
            foreach (var i in currentElement.NextElements)
            {
                result += terminalElementCounter(currentElement.NextElements[i.Key]);
            }
            return result;
        }

    }
}
