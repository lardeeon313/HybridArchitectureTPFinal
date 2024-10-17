using Core.Application.ComandQueryBus.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.DomainEvents.Customer
{
    internal class CustomerDeleted: DomainEvent
    {
        public string Id { get; set; }
       public CustomerDeleted(string id) { Id = id; }
    }
}
