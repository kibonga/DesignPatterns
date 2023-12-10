namespace Observer;

public class Subscription<T1> : IDisposable
{
    public IObserver<T1> Observer;
    private ISubscribable<T1> observable;

    public Subscription(ISubscribable<T1> observable, IObserver<T1> observer)
    {
        this.observable = observable;
        Observer = observer;
    }

    public void Dispose()
    {
        observable.Subscriptions.Remove(this);
    }
}
