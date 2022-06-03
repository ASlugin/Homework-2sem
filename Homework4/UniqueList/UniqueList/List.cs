/// <summary>
/// Class for data structure list
/// </summary>
public class List
{
    private class ListElement
    {
        public ListElement(int newValue, ListElement? next)
        {
            this.value = newValue;
            this.next = next;
        }
        public int value;
        public ListElement? next;
    }

    private ListElement? head;

    /// <summary>
    /// Amount of elements in the list
    /// </summary>
    public int Size { get; private set; } = 0;

    /// <summary>
    /// Check whether the list is empty
    /// </summary>
    /// <returns>If the list is empty return true, else return false</returns>
    public bool IsEmpty()
        => Size == 0;

    private ListElement FindElementByPosition(int position)
    {
        if (head == null)
        {
            throw new InvalidOperationException();
        }
        ListElement current = head;
        for (int i = 0; i < position; i++)
        {
            current = current.next!;
        }
        return current!;
    }

    /// <summary>
    /// Adds a new element to given position of the list
    /// </summary>
    /// <param name="value">Value of new element</param>
    /// <param name="position">Position for new element</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public virtual void Add(int value, int position)
    {
        if (position < 0 || position > Size)
        {
            throw new ArgumentOutOfRangeException("Invalid position");
        }

        if (position == 0 || head == null)
        {
            head = new ListElement(value, head);
            Size++;
            return;
        }
        ListElement elementBeforeNewElement = FindElementByPosition(position - 1);
        elementBeforeNewElement.next = new ListElement(value, elementBeforeNewElement.next);
        Size++;
    }

    /// <summary>
    /// Deletes an element at the given position from the list 
    /// </summary>
    /// <param name="position">Position to delete element</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void Delete(int position)
    {
        if (position < 0 || position >= Size)
        {
            throw new AttemptToDeleteNonexistentElement("Element with given position doesn't exist");
        }

        if (position == 0)
        {
            head = head?.next;
            Size--;
            return;
        }
        ListElement elementBeforeElementForDelete = FindElementByPosition(position - 1);
        elementBeforeElementForDelete.next = elementBeforeElementForDelete.next?.next;
        Size--;
    }

    /// <summary>
    /// Changes value of the element at the given position
    /// </summary>
    /// <param name="newValue">New value for the element</param>
    /// <param name="position">Position for the element to be changed</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public virtual void ChangeValueOfElement(int newValue, int position)
    {
        if (position < 0 || position >= Size)
        {
            throw new ArgumentOutOfRangeException("Invalid position");
        }
        FindElementByPosition(position).value = newValue;
    }

    /// <summary>
    /// Returns value of element at the given position
    /// </summary>
    /// <param name="position">Position for the element to return its value</param>
    /// <returns></returns>
    public int GetValue(int position)
    {
        if (position < 0 || position >= Size)
        {
            throw new ArgumentOutOfRangeException("Invalid position");
        }
        return FindElementByPosition(position).value;
    }

    /// <summary>
    /// Prints all elements of list
    /// </summary>
    public void Print()
    {
        ListElement? current = head;
        for (int i = 0; i < Size; i++)
        {
            Console.Write($"{current?.value} ");
            current = current?.next;
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Check whether given value exist in the list
    /// </summary>
    /// <returns>True if given value exist in list, else false</returns>
    public bool Exist(int value)
    {
        ListElement? current = head;
        for (int i = 0; i < Size; i++)
        {
            if (current?.value == value)
            {
                return true;
            }
            current = current?.next;
        }
        return false;
    }

    /// <summary>
    /// Returns position of first element with given value
    /// </summary>
    /// <param name="value">Value to search for element with this value</param>
    /// <returns>Position of first element or -1 if given value doesn't exist in list</returns>
    public int GetPositionOfFirstElementByValue(int value)
    {
        ListElement? current = head;
        for (int i = 0; i < Size; i++)
        {
            if (current?.value == value)
            {
                return i;
            }
            current = current?.next;
        }
        return -1;
    }
}
