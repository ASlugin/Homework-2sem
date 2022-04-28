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
            return new SparseVector(inputString);
        }
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
        return new SparseVector(elementsOfVector, length);
    }

    private static void Main(string[] args)
    {
        var vector1 = ReadVector();
        var vector2 = ReadVector();

        var sumOfVectors = SparseVector.Addition(vector1, vector2);
        Console.WriteLine("Sum of vectors:");
        sumOfVectors.PrintVector();

        var subtractionOfVectors = SparseVector.Subtraction(vector1, vector2);
        Console.WriteLine("Subtraction of vectors:");
        subtractionOfVectors.PrintVector();

        int multiplication = SparseVector.ScalarMultiplication(vector1, vector2);
        Console.WriteLine($"Scalar multiplacation: {multiplication}");

    }
}
