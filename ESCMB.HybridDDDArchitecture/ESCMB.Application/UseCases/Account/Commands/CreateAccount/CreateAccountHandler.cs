using Core.Application.ComandQueryBus.Buses;
using Core.Application.ComandQueryBus.Commands;
using ESCMB.Application.ApplicationServices.Customer;
using ESCMB.Application.DomainEvents.Account;
using ESCMB.Application.DomainEvents.ValidMail;
using ESCMB.Application.Repositories.Sql;
using ESCMB.Application.UseCases.Customer.Commands.CreateCustomer;
using ESCMB.Application.UseCases.Customer.Commands.ValidMailCustomer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Account.Commands.CreateAccount
{
    public class CreateAccountHandler(ICommandQueryBus domainBus,ICustomerRepository customerRepository, IAccountRepository accountRepository, ICustomerApplicationService customerApplicationService) : IRequestCommandHandler<ValidMailCustomerCommand,Unit>
    {
        private readonly ICommandQueryBus _domainBus = domainBus ?? throw new ArgumentNullException(nameof(domainBus));
        private readonly IAccountRepository _context = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        private readonly ICustomerRepository _customer = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        public async Task<Unit> Handle(ValidMailCustomerCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Customer customer = await customerRepository.FindOneAsync(request.Id);
            if (customer != null)
            {
                await accountRepository.AddAsync(new Domain.Entities.Account(customer));
                domainBus.Publish(new AccountCreated(), cancellationToken); //crear el ultimo HN para enviar segundo mail
            }
            else
            {
                Console.WriteLine("No existe el customer id");
            }
            throw new NotImplementedException();
        }
    }
}
