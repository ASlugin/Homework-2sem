/// <summary>
/// Exception is thrown if attempt was made to add existing value
/// </summary>
[Serializable]
public class AttemptToAddExistingValueException : Exception
{
    public AttemptToAddExistingValueException() { }
    public AttemptToAddExistingValueException(string message) : base(message) { }
    public AttemptToAddExistingValueException(string message, Exception inner) : base(message, inner) { }
    protected AttemptToAddExistingValueException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
