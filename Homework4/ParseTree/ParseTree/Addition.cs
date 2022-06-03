/// <summary>
/// Class defines addition
/// </summary>
class Addition : Operation
{
    public override double Calculate()
        => LeftSon!.Calculate() + RightSon!.Calculate();

    public override void Print()
    {
        Console.Write("( + ");
        base.Print();
    }
}
