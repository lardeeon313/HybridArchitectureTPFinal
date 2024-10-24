using Core.Application.ComandQueryBus.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ESCMB.Domain.Enums;

namespace ESCMB.Application.DomainEvents.Customer
{
    public class CustomerCreated : DomainEvent
    {
        [Required]
        public string id;
        public string CuilCuit { get; private set; }
        [Required]
        public string DocumentNumber { get; private set; }
        [Required]
        public string Email { get; private set; }
        [Required]
        public string FirstName { get; private set; }
        [Required]
        public string LastName { get; private set; }

        public CustomerCreated(string cuilCuit, string documentNumber, string email, string firstName, string lastName)
        {
            CuilCuit = cuilCuit;
            DocumentNumber = documentNumber;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
