using System;

namespace ParseTree
{
    class Division : Operation
    {
        public override double Calculate()
        {
            return (double)LeftSon.Calculate() / (double)RightSon.Calculate();
        }

        public override void Print()
        {
            Console.Write("( / ");
            base.Print();
        }
    }
}
