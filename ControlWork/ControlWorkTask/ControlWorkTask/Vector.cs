namespace Vector;
class SparseVector
{
    private Dictionary<int, int> vector;
    private int length = 0;

    private SparseVector(int length)
    {
        this.vector = new();
        this.length = length;
    }

    public SparseVector(string inputVector)
    {
        this.vector = new();
        this.length = inputVector.Length;
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
        this.vector = inputVector;
        this.length = length;
    }

    /// <summary>
    /// Creates new sparse vector with result of addition firstVector and secondVector
    /// </summary>
    /// <param name="firstVector"></param>
    /// <param name="secondVector"></param>
    /// <returns>If the length of the vectors is different, returns null, else returns new SparceVector</returns>
    public static SparseVector? Addition(SparseVector firstVector, SparseVector secondVector)
    {
        if (firstVector.length != secondVector.length)
        {
            return null;
        }
        SparseVector resultVector = new(firstVector.length);
        
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
    /// <param name="firstVector"></param>
    /// <param name="secondVector"></param>
    /// <returns>If length of the vectors is different, returns null, else returns new SparceVector</returns>
    public static SparseVector? Subtraction(SparseVector firstVector, SparseVector secondVector)
    {
        if (firstVector.length != secondVector.length)
        {
            return null;
        }
        SparseVector resultVector = new(firstVector.length);

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
    /// Puts in result the scalar multiplication of vectors
    /// </summary>
    /// <param name="firstVector"></param>
    /// <param name="secondVector"></param>
    /// <param name="result"></param>
    /// <returns>True if scalar multiplication is able to evaluate, else return false</returns>
    public static bool ScalarMultiplication(SparseVector firstVector, SparseVector secondVector, ref int result)
    {
        if (firstVector.length != secondVector.length)
        {
            return false;
        }
        result = 0;
        foreach (var elementsOfFirst in firstVector.vector)
        {
            if (secondVector.vector.ContainsKey(elementsOfFirst.Key))
            {
                result += elementsOfFirst.Value * secondVector.vector[elementsOfFirst.Key];
            }
        }
        return true;
    }

    /// <summary>
    /// Checks whether given vector is contatin only zero elements
    /// </summary>
    /// <param name="vector"></param>
    /// <returns>True if vectors contain only zero elements, else returns false</returns>
    public bool IsItZeroVector(SparseVector vector)
    {
        return vector.vector.Count == 0;
    }

    /// <summary>
    /// Prints length of vector and all nonzero elements in form [<index>, <value>]
    /// </summary>
    public void PrintVector()
    {
        Console.WriteLine($"Length of vector: {length}");
        foreach (var element in vector)
        {
            Console.WriteLine(element);
        }
    }
}
