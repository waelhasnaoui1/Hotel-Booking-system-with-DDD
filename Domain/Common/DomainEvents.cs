namespace Domain.Common;

public static class DomainEvents
{
    private static readonly List<Action<IDomainEvent>> _actions = new List<Action<IDomainEvent>>();

    public static void Register(Action<IDomainEvent> callback)
    {
        _actions.Add(callback);
    }

    public static void Raise<T>(T domainEvent) where T : IDomainEvent
    {
        foreach (var action in _actions)
        {
            action(domainEvent);
        }
    }

}