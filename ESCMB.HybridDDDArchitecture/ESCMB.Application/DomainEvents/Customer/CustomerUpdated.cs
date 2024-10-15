using Core.Application.ComandQueryBus.Notifications;
using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ESCMB.Domain.Enums;

namespace ESCMB.Application.DomainEvents.Customer
{
    internal class CustomerUpdated: DomainEvent
    {
        public string Id { get; set; }

        public string CuilCuit { get; set; }

        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public CustomerStatus Status { get; set; }
    }
}
