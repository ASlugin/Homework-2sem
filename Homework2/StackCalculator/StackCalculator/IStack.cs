/// <summary>
/// Interface for implement of stack
/// </summary>
public interface IStack
{
    /// <summary>
    /// True if stack is empty, else false
    /// </summary>
    bool IsEmpty { get; }

    /// <summary>
    /// Adds element to stack
    /// </summary>
    /// <param name="value">Value of element to add to stack</param>
    void Push(double value);

    /// <summary>
    /// Returns last element from stack and deletes it
    /// </summary>
    /// <returns>Element or null if stack is empty</returns>
    double? Pop();
}