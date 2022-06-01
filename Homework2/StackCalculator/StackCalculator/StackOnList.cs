/// <summary>
/// Implementation of stack on list
/// </summary>
public class StackOnList : IStack
{
    private class Element
    {
        public Element(double value, Element? next)
        {
            this.Value = value;
            this.Next = next;
        }

        public double Value { get; set; }
        public Element? Next;
    }

    private Element? head;
    
    public bool IsEmpty
    {
        get { return head == null; }
    }

    public void Push(double value)
    {
        head = new Element(value, head);
    }

    public double? Pop()
    {
        if (IsEmpty)
        {
            return null;
        }
        var result = head!.Value;
        head = head.Next;
        return result;
    }
}