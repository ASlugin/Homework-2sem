﻿[Serializable]
public class RepeatedDeclaringEdgeException : Exception
{
    public RepeatedDeclaringEdgeException() { }
    public RepeatedDeclaringEdgeException(string message) : base(message) { }
    public RepeatedDeclaringEdgeException(string message, Exception inner) : base(message, inner) { }
    protected RepeatedDeclaringEdgeException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}