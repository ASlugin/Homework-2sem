using System.Collections.Generic;

namespace Stack
{
    public class StackOnList : IStack
    {
        public StackOnList()
        {
            this.stack = new List<double>();
        }

        private List<double> stack;

        public bool IsEmpty()
        {
            return stack.Count == 0;
        }

        public void Push(double value)
        {
            stack.Add(value);
        }

        public double? Pop()
        {
            if (IsEmpty())
            {
                return null;
            }
            var result = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return result;
        }
    }
}
