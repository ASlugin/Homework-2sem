namespace ParseTree;

class Division : Operation
{
    public override double Calculate()
    {
        if (RightSon.Calculate() == 0)
        {
            throw new DivideByZeroException();
        }
        return (double)LeftSon.Calculate() / (double)RightSon.Calculate();
    }

    public override void Print()
    {
        Console.Write("( / ");
        base.Print();
    }
}
