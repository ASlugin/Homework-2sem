/// <summary>
/// Implementation of stack on array
/// </summary>
public class StackOnArray : IStack
{
    public StackOnArray()
    {
        this.array = new double[10];
    }

    private double[] array;
    private int position = 0;

    public bool IsEmpty
    {
        get { return position == 0; }
    }

    public void Push(double value)
    {
        array[position] = value;
        position++;
        if (position == array.Length)
        {
            Array.Resize(ref array, array.Length * 2);
        }
    }

    public double? Pop()
    {
        if (IsEmpty)
        {
            return null;
        }
        double result = array[--position];
        return result;
    }
}