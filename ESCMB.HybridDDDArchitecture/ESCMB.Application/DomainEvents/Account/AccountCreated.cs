using Core.Application.ComandQueryBus.Notifications;
using Core.Domain.Entities;
using ESCMB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ESCMB.Domain.Enums;

namespace ESCMB.Application.DomainEvents.Account
{
    public class AccountCreated : DomainEvent
    {
       public AccountCreated() { }

    }
}
