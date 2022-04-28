[Serializable]
public class DequeueFromEnptyListException : Exception
{
    public DequeueFromEnptyListException() { }
    public DequeueFromEnptyListException(string message) : base(message) { }
    public DequeueFromEnptyListException(string message, Exception inner) : base(message, inner) { }
    protected DequeueFromEnptyListException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}