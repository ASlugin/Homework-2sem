namespace Queue;

/// <summary>
/// Exception is thrown if attempt was made dequeue from empty queue
/// </summary>
[Serializable]
public class DequeueFromEmptyQueueException : InvalidOperationException
{
    public DequeueFromEmptyQueueException() { }
    public DequeueFromEmptyQueueException(string message) : base(message) { }
    public DequeueFromEmptyQueueException(string message, Exception inner) : base(message, inner) { }
    protected DequeueFromEmptyQueueException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}