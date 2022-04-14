namespace Vector;

class Program
{
    private static SparseVector ReadVector()
    {
        Console.Write("Enter a sparse vector in string or type enter: ");
        var inputString = Console.ReadLine();
        if (inputString == null)
        {
            throw new NullReferenceException();
        }

        if (inputString.Length > 0)
        {
            var vector = new SparseVector(inputString);
            return vector;
        }
        else
        {
            Console.Write("Enter length a vector: ");
            if (!int.TryParse(Console.ReadLine(), out int length))
            {
                throw new InvalidDataException();
            }
            Console.Write("Enter number of nonzero elements: ");
            if (!int.TryParse(Console.ReadLine(), out int numberOfElements))
            {
                throw new InvalidDataException();
            }

            Dictionary<int, int> elementsOfVector = new();

            for (int i = 0; i < numberOfElements; i++)
            {
                Console.Write($"Enter index withih [0, {length - 1}]: ");
                if (!int.TryParse(Console.ReadLine(), out int index) || index >= length || index < 0 || elementsOfVector.ContainsKey(index))
                {
                    throw new InvalidDataException();
                }
                Console.Write("Enter value on this index: ");
                if (!int.TryParse(Console.ReadLine(), out int value))
                {
                    throw new InvalidDataException();
                }
                elementsOfVector.Add(index, value);
            }
            var vector = new SparseVector(elementsOfVector, length);
            return vector;
        }
    }

    private static void Main(string[] args)
    {
        var vector1 = ReadVector();
        var vector2 = ReadVector();

        var sumOfVectors = SparseVector.Addition(vector1, vector2);
        if (sumOfVectors == null)
        {
            Console.WriteLine("Vectors have different length!");
            return;
        }
        sumOfVectors.PrintVector();

        var subctractionOfVectors = SparseVector.Subtraction(vector1, vector2);
        if (subctractionOfVectors == null)
        {
            Console.WriteLine("Vectors have different length!");
            return;
        }
        subctractionOfVectors.PrintVector();

        int multiplication = 0;
        if (SparseVector.ScalarMultiplication(vector1, vector2, ref multiplication))
        {
            Console.WriteLine($"Scalar multiplication: {multiplication}");
        }
    }
}
