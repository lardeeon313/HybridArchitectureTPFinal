using Core.Domain.Entities;
using ESCMB.Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ESCMB.Domain.Enums;
namespace ESCMB.Domain.Entities
{
    
    public class Account : DomainEntity<Account, AccountValidator>
    {
        [Key]
       
        public string Id { get; set; }
        public string CBU {  get; set; }
        public string Alias { get; set; }
        public double Monto { get; set; }
       public Customer Customer { get; set; }
       public AccountStatus AccountStatus { get; set; }


        public Account(Customer customer)
        {
            Id= Guid.NewGuid().ToString();
            CBU = GenerateRandomNumericString(22);
            Alias = GenerateRandomAlphabeticString(10);
            Monto = 0;
            Customer = customer;
            AccountStatus = AccountStatus.Active;
        }
        private string GenerateRandomNumericString(int length)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat("0123456789", length)
                              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string GenerateRandomAlphabeticString(int length)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ", length)
                              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
