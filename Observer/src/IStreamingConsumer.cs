namespace Observer;

public interface IStreamingConsumer<UpdateMessage> : IObserver<UpdateMessage>
{
    public void OnCompleted()
    {
    }

    public void OnNext(UpdateMessage updateMessage)
    {
    }

    public void OnError(Exception error)
    {
    }
}
