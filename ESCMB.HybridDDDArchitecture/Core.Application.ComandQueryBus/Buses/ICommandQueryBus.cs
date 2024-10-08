﻿using MediatR;

namespace Core.Application.ComandQueryBus.Buses
{
    public interface ICommandQueryBus
    {
        Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
            where TNotification : INotification;

        Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    }
}
