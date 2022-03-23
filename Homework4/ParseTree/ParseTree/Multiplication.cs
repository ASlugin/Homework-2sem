using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree
{
    class Multiplication : Operation
    {
        public override double Calculate()
        {
            return LeftSon.Calculate() * RightSon.Calculate();
        }

        public override void Print()
        {
            Console.Write("( * ");
            base.Print();
        }
    }
}
