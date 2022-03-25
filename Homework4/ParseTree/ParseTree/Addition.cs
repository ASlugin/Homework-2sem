namespace ParseTree
{
    class Addition : Operation
    {
        public override double Calculate()
        {
            return LeftSon.Calculate() + RightSon.Calculate();
        }

        public override void Print()
        {
            Console.Write("( + ");
            base.Print();
        }
    }
}
