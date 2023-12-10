namespace Observer;

public interface ISubscribable<T1>
{
    public HashSet<Subscription<T1>> Subscriptions { get; }
}
