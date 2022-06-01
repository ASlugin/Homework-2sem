/// <summary>
/// Class of data structure Trie
/// </summary>
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
            this.AmountOfPrefix = 0;
        }

        public Dictionary<char, Element> NextElements;
        public int AmountOfPrefix { get; set; }
        public bool Terminal { get; set; }
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
        for (var i = 0; i < element.Length; i++)
        {
            if (currentElement.NextElements.ContainsKey(element[i]))
            {
                if (i == element.Length - 1)
                {
                    if (!currentElement.NextElements[element[i]].Terminal)
                    {
                        Size++;
                        currentElement.NextElements[element[i]].Terminal = true;
                        currentElement.NextElements[element[i]].AmountOfPrefix++;
                        return true;
                    }
                    return false;
                }
                currentElement = currentElement.NextElements[element[i]];
                currentElement.AmountOfPrefix++;
            }
            else
            {
                currentElement.NextElements.Add(element[i], new Element());
                if (i == element.Length - 1)
                {
                    currentElement.NextElements[element[i]].Terminal = true;
                    currentElement.NextElements[element[i]].AmountOfPrefix++;
                    Size++;
                    return true;
                }
                currentElement = currentElement.NextElements[element[i]];
                currentElement.AmountOfPrefix++;
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
        for (var i = 0; i < element.Length; ++i)
        {
            if (currentElement.NextElements.ContainsKey(element[i]))
            {
                currentElement = currentElement.NextElements[element[i]];
                if (i == element.Length - 1 && currentElement.Terminal)
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
        return RemoveRecursive(root, 0, element, ref removeThisElement);
    }

    private bool RemoveRecursive(Element currentElement, int index, string element, ref bool removeThisElement)
    {
        if (index == element.Length)
        {
            if (currentElement.Terminal)
            {
                Size--;
                currentElement.Terminal = false;
                currentElement.AmountOfPrefix--;
                removeThisElement = currentElement.NextElements.Count == 0;
                return true;
            }
            return false;
        }

        if (currentElement.NextElements.ContainsKey(element[index]))
        {
            if (!RemoveRecursive(currentElement.NextElements[element[index]], index + 1, element, ref removeThisElement))
            {
                return false;
            }
            if (removeThisElement)
            {
                currentElement.NextElements.Remove(element[index]);
                removeThisElement = currentElement.NextElements.Count == 0 && !currentElement.Terminal;
            }
            currentElement.AmountOfPrefix--;
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
        return currentElement.AmountOfPrefix;
    }
}
