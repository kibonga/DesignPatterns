namespace Observer;

public class StreamingException : Exception
{
    public StreamingException(string reason, Exception rootCause)
        : base(reason, rootCause)
    {
    }
}
