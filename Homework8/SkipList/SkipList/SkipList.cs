namespace SkipList;

using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Class with implementation data structure Skip List
/// </summary>
public class SkipList<T> : IList<T> where T : IComparable<T>
{
    public SkipList()
    {
        bottomHead = new Node(default);
        topHead = bottomHead;
        amountOfLevels = 1;
    }

    private class Node
    {
        public T? Value { get; private set; }

        public Node? Next { get; set; }

        public Node? Down { get; set; }

        public Node(T? value)
        {
            this.Value = value;
        }
    }

    private Node topHead;
    private Node bottomHead;
    private int amountOfLevels;

    public int Count { get; private set; }

    public bool IsReadOnly { get; }

    public void Add(T newValue)
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException();
        }

        ++Count;
        if (bottomHead.Next == null)
        {
            bottomHead.Next = new Node(newValue);
            return;
        }
        AddRecursive(topHead, newValue);

        if (Count > Math.Pow(2, amountOfLevels))
        {
            var newHead = new Node(default);
            newHead.Down = topHead;
            topHead = newHead;
            ++amountOfLevels;
        }
    }

    private Node? AddRecursive(Node currentNode, T newValue)
    {
        while (currentNode.Next != null && newValue.CompareTo(currentNode.Next.Value) >= 0)
        {
            currentNode = currentNode.Next;
        }

        Node? downNode;
        if (currentNode.Down == null)
        {
            downNode = null;
        }
        else
        {
            downNode = AddRecursive(currentNode.Down, newValue);
        }

        if (downNode != null || currentNode.Down == null)
        {
            Node? nextNodeAfterCurrent = currentNode.Next;
            currentNode.Next = new Node(newValue);
            currentNode.Next.Down = downNode;
            currentNode.Next.Next = nextNodeAfterCurrent;

            Random random = new();
            if (random.Next(2) == 1)
            {
                return currentNode.Next;
            }
            return null;
        }
        return null;
    }

    public int IndexOf(T item)
    {
        int counter = 0;
        Node? currentNode = bottomHead.Next;
        while (currentNode != null)
        {
            if (currentNode.Value!.Equals(item))
            {
                return counter;
            }
            currentNode = currentNode.Next;
            ++counter;
        }
        return -1;
    }

    public void Insert(int index, T item)
    {
        throw new NotSupportedException("New element cannot be inserted by index, skip list is sorted list.");
    }

    public bool Contains(T item)
    {
        var currentNode = topHead;
        while (currentNode != null)
        {
            while (currentNode.Next != null && item.CompareTo(currentNode.Next.Value) > 0)
            {
                currentNode = currentNode.Next;
            }
            if (currentNode.Next != null && currentNode.Next!.Value!.Equals(item))
            {
                return true;
            }
            currentNode = currentNode.Down;
        }
        return false;
    }

    public void Clear()
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException();
        }
        bottomHead = new Node(default);
        topHead = bottomHead;
        amountOfLevels = 1;
        Count = 0;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (arrayIndex >= Count || array.Length < Count - arrayIndex)
        {
            throw new ArgumentOutOfRangeException();
        }

        var currentNode = bottomHead!.Next;
        int counter = 0;
        while (counter < arrayIndex)
        {
            currentNode = currentNode?.Next;
            counter++;
        }
        while (currentNode != null)
        {
            array[counter - arrayIndex] = currentNode.Value!;
            currentNode = currentNode.Next;
            counter++;
        }
    }

    public T this[int index]
    {
        get
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            int counter = 0;
            var currentNode = bottomHead!.Next;
            while (counter < index)
            {
                currentNode = currentNode!.Next;
                ++counter;
            }
            return currentNode!.Value!;
        }
        set
        {
            throw new NotSupportedException("Value of element cannot be changed by index, skip list is sorted list.");
        }
    }

    public bool Remove(T item)
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException();
        }

        if (RemoveRecursive(topHead!, item))
        {
            Count--;
            return true;
        }
        return false;
    }

    private bool RemoveRecursive(Node currentNode, T item)
    {
        while (currentNode.Next != null && item.CompareTo(currentNode.Next.Value) > 0)
        {
            currentNode = currentNode.Next;
        }
        bool removed = false;
        if (currentNode.Down != null)
        {
            removed = RemoveRecursive(currentNode.Down, item);
        }
        if (currentNode.Next != null && currentNode.Next.Value!.Equals(item))
        {
            currentNode.Next = currentNode.Next.Next;
            return true;
        }
        return removed;
    }

    public void RemoveAt(int index)
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException();
        }
        if (index >= Count || Count < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        var value = this[index];
        Remove(value);
        //Для пользователя элементы с одинаковыми значениями не отличаются,
        //поэтому можно удалить первый элемент с таким значением
        //Пользователь всё равно ничего не заметит, наверное..
    }

    public IEnumerator GetEnumerator()
    {
        var arrayOfElements = new T[Count];
        CopyTo(arrayOfElements, 0);
        return arrayOfElements.GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return (IEnumerator<T>)GetEnumerator();
    }
}
