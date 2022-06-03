/// <summary>
/// Class defines substraction
/// </summary>
class Subtraction : Operation
{
    public override double Calculate()
    {
        return LeftSon!.Calculate() - RightSon!.Calculate();
    }

    public override void Print()
    {
        Console.Write("( - ");
        base.Print();
    }
}
