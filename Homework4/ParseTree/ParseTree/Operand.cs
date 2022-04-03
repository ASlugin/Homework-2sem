namespace ParseTree;

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
