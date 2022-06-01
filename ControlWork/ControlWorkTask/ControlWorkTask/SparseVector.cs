namespace Vector;

/// <summary>
/// Class for sparse vector
/// </summary>
public class SparseVector
{
    private Dictionary<int, int> vector;
    public int Length { get; private set; } = 0;

    private SparseVector(int length)
    {
        this.vector = new();
        this.Length = length;
    }

    public SparseVector(string inputVector)
    {
        this.vector = new();
        this.Length = inputVector.Length;
        for (int i = 0; i < inputVector.Length; i++)
        {
            int currentNumber = int.Parse(inputVector.Substring(i, 1));
            if (currentNumber != 0)
            {
                vector.Add(i, currentNumber);
            }
        }
    }

    public SparseVector(Dictionary<int, int> inputVector, int length)
    {
        foreach (var position in inputVector)
        {
            if (inputVector[position.Key] == 0)
            {
                inputVector.Remove(position.Key);
            }
        }
        this.vector = inputVector;
        this.Length = length;
    }

    /// <summary>
    /// Creates new sparse vector with result of addition firstVector and secondVector
    /// </summary>
    /// <returns>Returns new Sparse vector</returns>
    public static SparseVector Addition(SparseVector firstVector, SparseVector secondVector)
    {
        if (firstVector.Length != secondVector.Length)
        {
            throw new ArgumentException("Lengths of vectors are different!");
        }
        SparseVector resultVector = new(firstVector.Length);
        
        foreach (var elementOfFirst in firstVector.vector)
        {
            if (secondVector.vector.ContainsKey(elementOfFirst.Key))
            {
                int sum = elementOfFirst.Value + secondVector.vector[elementOfFirst.Key];
                if (sum != 0)
                {
                    resultVector.vector.Add(elementOfFirst.Key, sum);
                }
            }
            else
            {
                int sum = elementOfFirst.Value;
                if (sum != 0)
                {
                    resultVector.vector.Add(elementOfFirst.Key, sum);
                }
            }
        }
        foreach (var elementOfSecond in secondVector.vector)
        {
            if (!resultVector.vector.ContainsKey(elementOfSecond.Key))
            {
                int sum = elementOfSecond.Value;
                if (sum != 0)
                {
                    resultVector.vector.Add(elementOfSecond.Key, sum);
                }
            }
        }
        return resultVector;
    }

    /// <summary>
    /// Creates new sparse vector with result of subtraction firstVector and secondVector
    /// </summary>
    /// <returns>If length of the vectors is different, returns null, else returns new SparceVector</returns>
    public static SparseVector Subtraction(SparseVector firstVector, SparseVector secondVector)
    {
        if (firstVector.Length != secondVector.Length)
        {
            throw new ArgumentException("Lengths of vectors are different!");
        }
        SparseVector resultVector = new(firstVector.Length);

        foreach (var elementOfFirst in firstVector.vector)
        {
            if (secondVector.vector.ContainsKey(elementOfFirst.Key))
            {
                int sum = elementOfFirst.Value - secondVector.vector[elementOfFirst.Key];
                if (sum != 0)
                {
                    resultVector.vector.Add(elementOfFirst.Key, sum);
                }
            }
            else
            {
                int sum = elementOfFirst.Value;
                if (sum != 0)
                {
                    resultVector.vector.Add(elementOfFirst.Key, sum);
                }
            }
        }
        foreach (var elementOfSecond in secondVector.vector)
        {
            if (!resultVector.vector.ContainsKey(elementOfSecond.Key))
            {
                int sum = elementOfSecond.Value * (-1);
                if (sum != 0)
                {
                    resultVector.vector.Add(elementOfSecond.Key, sum);
                }
            }
        }
        return resultVector;
    }

    /// <summary>
    /// Calculates the scalar multiplication of vectors
    /// </summary>
    /// <returns>Returns the scalat multiplication of vectors</returns>
    public static int ScalarMultiplication(SparseVector firstVector, SparseVector secondVector)
    {
        if (firstVector.Length != secondVector.Length)
        {
            throw new ArgumentException("Lengths of vectors are different!");
        }
        int result = 0;
        foreach (var elementsOfFirst in firstVector.vector)
        {
            if (secondVector.vector.ContainsKey(elementsOfFirst.Key))
            {
                result += elementsOfFirst.Value * secondVector.vector[elementsOfFirst.Key];
            }
        }
        return result;
    }

    /// <summary>
    /// Checks whether given vector is contatin only zero elements
    /// </summary>
    /// <returns>True if vectors contain only zero elements, else returns false</returns>
    public static bool IsItZeroVector(SparseVector vector)
        => vector.vector.Count == 0;

    /// <summary>
    /// Prints length of vector and all nonzero elements in form [<index>, <value>]
    /// </summary>
    public void PrintVector()
    {
        Console.WriteLine($"Length of vector: {Length}");
        foreach (var element in vector)
        {
            Console.WriteLine(element);
        }
    }
}
