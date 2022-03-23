using System;

namespace ParseTree
{
    class Tree 
    {
        private INode root;
        public Tree(string expression)
        {
            var elements = expression.Split(new char[] {' ', '(', ')'}, StringSplitOptions.RemoveEmptyEntries);
            this.root = AddNodeRecursive(elements);
        }

        private INode AddNodeRecursive(string[] elements)
        {
            if (elements.Length == 0)
            {
                throw new ArgumentException("Invalid expression!");
            }

            int value = 0;
            if (int.TryParse(elements[0], out value))
            {
                return new Operand(value);
            }

            Operation newNode;
            switch (elements[0])
            {
                case "+":
                    newNode = new Addition();
                    break;
                case "-":
                    newNode = new Subtraction();
                    break;
                case "*":
                    newNode = new Multiplication();
                    break;
                case "/":
                    newNode = new Division();
                    break;
                default:
                    throw new ArgumentException("Invalid expression!");
            }

            string[] elementsWithoutFirstElement = elements.Skip(1).ToArray();
            newNode.LeftSon = AddNodeRecursive(elementsWithoutFirstElement);
            elementsWithoutFirstElement = elements.Skip(2).ToArray();
            newNode.RightSon = AddNodeRecursive(elementsWithoutFirstElement);
            return newNode;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Print()
        {
            root.Print();
            Console.WriteLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double Calculate()
        {
            return root.Calculate();
        }

    }
}
