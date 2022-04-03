namespace ParseTree;

abstract class Operation : INode
{
    public INode LeftSon { get; set; }
    public INode RightSon { get; set; }

    public virtual void Print()
    {
        LeftSon.Print();
        RightSon.Print();
        Console.Write(") ");
    }
    public abstract double Calculate();
}
