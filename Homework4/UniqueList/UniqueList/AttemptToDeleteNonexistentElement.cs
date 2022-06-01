/// <summary>
/// Exception is thrown if attempt was made to delete nonexisting element
/// </summary>
[Serializable]
public class AttemptToDeleteNonexistentElement : Exception
{
    public AttemptToDeleteNonexistentElement() { }
    public AttemptToDeleteNonexistentElement(string message) : base(message) { }
    public AttemptToDeleteNonexistentElement(string message, Exception inner) : base(message, inner) { }
    protected AttemptToDeleteNonexistentElement(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
