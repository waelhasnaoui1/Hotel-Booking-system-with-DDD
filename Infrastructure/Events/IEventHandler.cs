namespace Infrastructure.Events;

public interface IEventHandler<TEvent>
{
    Task HandleAsync(TEvent eventToHandle);
}