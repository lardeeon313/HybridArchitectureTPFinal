﻿using MediatR;

namespace Core.Application.ComandQueryBus.Buses
{
    public class MediatrCommandQueryBus(IMediator mediator) : ICommandQueryBus
    {
        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            return mediator.Publish(notification, cancellationToken);
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            return mediator.Send(request, cancellationToken);
        }
    }
}
