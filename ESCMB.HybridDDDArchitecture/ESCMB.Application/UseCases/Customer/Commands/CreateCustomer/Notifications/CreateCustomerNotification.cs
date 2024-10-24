using ESCMB.Application.Adapters;
using ESCMB.Application.DomainEvents.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Customer.Commands.CreateCustomer.Notifications
{
    internal class CreateCustomerNotification(ISmtpEmailSenderAdapter smtpEmailSenderAdapter) : INotificationHandler<CustomerCreated>
    {
        public async Task Handle(CustomerCreated notification, CancellationToken cancellationToken)
        {
            string sender = "lardeeon123@gmail.com";
            string msgbody = $@"
                <div style='font-family: Arial, sans-serif; color: #333; padding: 20px;'>
                    <h2 style='color: #0056b3;'>Bienvenido a NETBanking, {notification.FirstName} {notification.LastName}!</h2>
                    <p>
                        Para completar tu registro, por favor confirma tu cuenta accediendo al siguiente enlace:
                    </p>
                    <p>
                        <a href='http://localhost:5000/api/v1/validMail/{notification.id}' style='background-color: #0056b3; color: #fff; padding: 10px 20px; text-decoration: none; border-radius: 5px;'>Click aquí</a>
                    </p>
                    <br/>
                    <p>Saludos cordiales,</p>
                    <p style='font-weight: bold;'>NETBanking TEAM</p>
                </div>";
            string subject = "Registro NETBanking";

            await smtpEmailSenderAdapter.SendEmailAsync(sender, subject, msgbody, notification.Email);

            Console.WriteLine("Se envio el correo");
            
        }
    }
}
