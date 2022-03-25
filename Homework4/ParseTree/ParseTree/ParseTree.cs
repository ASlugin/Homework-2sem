namespace ParseTree
{
    class Tree 
    {
        private INode root;
        public Tree(string expression)
        {
            var elements = expression.Split(new char[] {' ', '(', ')'}, StringSplitOptions.RemoveEmptyEntries);
            this.root = AddNodeRecursive(ref elements);
            if (elements.Length > 1)
            {
                throw new ArgumentException("Incorrect expression: too many arguments");
            }
        }

        private INode AddNodeRecursive(ref string[] elements)
        {
            if (elements.Length == 0)
            {
                throw new ArgumentException("Incorrect expression: not enough arguments");
            }

            int value = 0;
            if (int.TryParse(elements[0], out value))
            {
                return new Operand(value);
            }

            Operation newNode = elements[0] switch
            {
                "+" => newNode = new Addition(),
                "-" => newNode = new Subtraction(),
                "*" => newNode = new Multiplication(),
                "/" => newNode = new Division(),
                _ => throw new ArgumentException("Incorrect expression: invalid character")
            };

            elements = elements.Skip(1).ToArray();
            newNode.LeftSon = AddNodeRecursive(ref elements);
            elements = elements.Skip(1).ToArray();
            newNode.RightSon = AddNodeRecursive(ref elements);
            return newNode;
        }

        /// <summary>
        /// Prints expression that contained in tree
        /// </summary>
        public void Print()
        {
            root.Print();
            Console.WriteLine();
        }

        /// <summary>
        /// Calculates expression that contained in tree
        /// </summary>
        /// <returns>Result of calculating the expression</returns>
        public double Calculate()
        {
            return root.Calculate();
        }

    }
}
