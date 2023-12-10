namespace Observer;

public class UpdateMessage
{
    public int Id { get; set; }
    public string Reason { get; set; }
    public Status Status { get; set; }

    public override string ToString()
    {
        return $"Update message: " +
               $" id={Id}" +
               $", reason={Reason}" +
               $", status={Status}";
    }
}

public enum Status
{
    CLOSED,
    OPEN,
    AVAILABLE,
    UNAVAILABLE,
    IN_PROGRESS
}
