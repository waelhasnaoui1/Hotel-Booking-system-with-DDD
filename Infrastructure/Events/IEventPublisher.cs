namespace Infrastructure.Events;

public interface IEventPublisher
{
    Task PublishAsync<TEvent>(TEvent eventToPublish);

}