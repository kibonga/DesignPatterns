namespace Observer;

public class Consumer : IStreamingConsumer<UpdateMessage>
{
    public void OnCompleted()
    {
        Log.Logger.Info("Consumer has completed.");
        Console.WriteLine("Consumer has completed");
    }

    public void OnNext(UpdateMessage updateMessage)
    {
        Log.Logger.Info($"Update message received: {updateMessage}");
        Console.WriteLine($"Update message received: {updateMessage}");
    }

    public void OnError(Exception error)
    {
        Log.Logger.Error("Streaming failed.");
        Console.WriteLine("Streaming failed");
    }
}
