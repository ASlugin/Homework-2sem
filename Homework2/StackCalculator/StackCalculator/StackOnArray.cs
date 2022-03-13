namespace Stack
{
    public class StackOnArray : IStack
    {
        public StackOnArray()
        {
            this.array = new double[10];
        }

        private double[] array;
        private int position = 0;

        public bool IsEmpty()
        {
            return position == 0;
        }

        public void Push(double value)
        {
            array[position++] = value;
            if (position == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }
        }

        public double? Pop()
        {
            if (position == 0)
            {
                return null;
            }
            double result = array[--position];
            array[position] = 0;
            return result;
        }
    }
}
