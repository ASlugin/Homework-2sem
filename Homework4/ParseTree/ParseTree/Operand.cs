/// <summary>
/// Class for node of tree, that contain number
/// </summary>
class Operand : INode
{
    private double value;

    public Operand(double newValue)
    {
        this.value = newValue;
    }

    public void Print()
    {
        Console.Write($"{value} ");
    }

    public double Calculate()
    {
        return value;
    }
}
