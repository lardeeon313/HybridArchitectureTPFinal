using Core.Application.ComandQueryBus.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.DomainEvents.ValidMail
{
    public class MailCustomerValidated : DomainEvent
    {

        public string id;
        public MailCustomerValidated(string id) { id = id; }
        public MailCustomerValidated() { }
    }
}
