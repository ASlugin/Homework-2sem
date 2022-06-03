/// <summary>
/// Class defines multiplication
/// </summary>
class Multiplication : Operation
{
    public override double Calculate()
    {
        return LeftSon!.Calculate() * RightSon!.Calculate();
    }

    public override void Print()
    {
        Console.Write("( * ");
        base.Print();
    }
}
