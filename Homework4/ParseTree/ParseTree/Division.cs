/// <summary>
/// Class defines division
/// </summary>
class Division : Operation
{
    public override double Calculate()
    {
        if (Math.Abs(RightSon!.Calculate()) < double.Epsilon)
        {
            throw new DivideByZeroException();
        }
        return (double)LeftSon!.Calculate() / (double)RightSon!.Calculate();
    }

    public override void Print()
    {
        Console.Write("( / ");
        base.Print();
    }
}
