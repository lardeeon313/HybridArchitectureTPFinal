using ESCMB.Application.DomainEvents.Account;
using ESCMB.Application.Repositories.Sql;
using ESCMB.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Account.Commands.CreateAccount.Notificactions
{
    public class CreateAccountNotification(IAccountRepository accountRepository) : INotificationHandler<AccountCreated>
    {
        private readonly IAccountRepository _context = accountRepository ?? throw new ArgumentNullException(nameof(customerRepository));

        public async Task Handle(AccountCreated notification, CancellationToken cancellationToken)
        {
            Domain.Entities.Account account = new Domain.Entities.Account(notification.Id,notification.);
            string createdId = await _context.AddOneAsync();
            return ;
        }
    }
}
