using Core.Application.ComandQueryBus.Buses;
using ESCMB.Application.DomainEvents.Account;
using ESCMB.Application.DomainEvents.Customer;
using ESCMB.Application.DomainEvents.ValidMail;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Customer.Commands.ValidMailCustomer
{
    internal class ValidMailCustomerHandler(ICommandQueryBus domainBus, ICustomerRepository customerRepository) : IRequestHandler<ValidMailCustomerCommand, Unit>
    {

        private readonly ICommandQueryBus _domainBus = domainBus ?? throw new ArgumentNullException(nameof(domainBus));
        private readonly ICustomerRepository _context = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));


        public async Task<Unit> Handle(ValidMailCustomerCommand request, CancellationToken cancellationToken)
        {

            Domain.Entities.Customer entity = await _context.FindOneAsync(request.Id) ?? throw new EntityDoesNotExistException();
            entity.Status= Domain.Enums.CustomerStatus.Confirmed;
            customerRepository.Update(entity);
            AccountCreated accountCreated = new AccountCreated();
            await _domainBus.Publish(new MailCustomerValidated(entity.Id), cancellationToken);



            return Unit.Value;

        }
    }
}
