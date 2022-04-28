namespace Queue;
using System.Collections.Generic;

/// <summary>
/// Class for queue with priorities
/// </summary>
public class QueuePriority<T>
{
    private List<(T, int)> list;

    /// <summary>
    /// This property is true if list is empty, else false
    /// </summary>
    public bool Empty { get; private set; }

    public QueuePriority()
    {
        list = new();
        Empty = true;
    }

    /// <summary>
    /// Adds new element to priority queue
    /// </summary>
    /// <param name="value">Value of new element</param>
    /// <param name="priority">Priority of new element</param>
    public void Enqueue(T value, int priority)
    {
        if (list.Count == 0)
        {
            list.Add((value, priority));
            Empty = false;
            return;
        }

        var indexForInsert = 0;
        foreach (var element in list)
        {
            if (element.Item2 < priority)
            {
                list.Insert(indexForInsert, (value, priority));
                return;
            }
            indexForInsert++;
        }
        list.Add((value, priority));
    }

    /// <summary>
    /// Returns elements with the highest priority or which is in queue the longest
    /// </summary>
    /// <exception cref="Exception">If list is empty throw this exception</exception>
    public T Dequeue()
    {
        if (list.Count == 0)
        {
            throw new DequeueFromEnptyListException();
        }
        T result = list[0].Item1;
        list.RemoveAt(0);
        if (list.Count == 0)
        {
            Empty = true;
        }
        return result;
    }
}
