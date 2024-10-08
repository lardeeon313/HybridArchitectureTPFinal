using MediatR;

namespace Core.Application.ComandQueryBus.Notifications
{
    public interface IRequestNotificationHandler<in TNotification> : INotificationHandler<TNotification>
        where TNotification : INotification
    {
    }
}
