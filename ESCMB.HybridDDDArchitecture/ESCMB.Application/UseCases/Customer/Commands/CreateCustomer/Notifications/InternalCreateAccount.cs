using Core.Application.ComandQueryBus.Buses;
using ESCMB.Application.DomainEvents.Customer;
using ESCMB.Application.DomainEvents.ValidMail;
using ESCMB.Application.UseCases.Customer.Commands.ValidMailCustomer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Customer.Commands.CreateCustomer.Notifications
{
    public class InternalCreateAccount(ICommandQueryBus commandQueryBus) : INotificationHandler<MailCustomerValidated>
    {
        private readonly ICommandQueryBus _commandQueryBus = commandQueryBus ?? throw new ArgumentNullException(nameof(commandQueryBus));


        public async Task Handle(MailCustomerValidated notification, CancellationToken cancellationToken)
        {
          await _commandQueryBus.Send(new ValidMailCustomerCommand { Id=notification.id});
        }
    }
}
