using System.Collections.Concurrent;

namespace Observer;

public class StreamingClient : ISubscribable<UpdateMessage>
{
    private readonly HashSet<Subscription<UpdateMessage>> _subscriptions = new();
    private readonly ConcurrentQueue<UpdateMessage> _messageQueue = new();
    public HashSet<Subscription<UpdateMessage>> Subscriptions { get; }

    public StreamingClient()
    {
        InitMessageQueue();
    }

    public void Subscribe(IStreamingConsumer<UpdateMessage> consumer)
    {
        Subscription<UpdateMessage> subscription = new Subscription<UpdateMessage>(this, consumer);
        _subscriptions.Add(subscription);
    }

    public void Notify()
    {
        try
        {
            while (_messageQueue.TryDequeue(out var message))
            {
                foreach (var s in _subscriptions)
                {
                    s.Observer.OnNext(message);
                }
            }

            foreach (var s in _subscriptions)
            {
                s.Observer.OnCompleted();
            }
        }
        catch (Exception ex)
        {
            foreach (var s in _subscriptions)
            {
                StreamingException streamingException = new("An error occured while streaming", ex);
                s.Observer.OnError(streamingException);
            }
        }
    }

    private void InitMessageQueue()
    {
        var rnd = new Random();
        for (int i = 1; i < 100; i++)
        {
            _messageQueue.Enqueue(new UpdateMessage()
            {
                Id = i,
                Reason = $"Reason no.{i}",
                Status = (Status)rnd.Next(0, 5)
            });
        }
    }
}
