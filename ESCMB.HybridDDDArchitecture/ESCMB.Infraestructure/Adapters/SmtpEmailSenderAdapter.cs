
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ESCMB.Application.Adapters;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;



namespace ESCMB
{
    internal class SmtpEmailSenderAdapter : ISmtpEmailSenderAdapter
    {
        public ISendGridClient Client { get; private set; }

        public SmtpEmailSenderAdapter(IOptions<SendGridClientOptions> options)
        {
            Client = new SendGridClient(options.Value.ApiKey);
        }
        public async Task SendEmailAsync(string senderName, string discussion, string message, string recipient)
        {
            var msg = MailHelper.CreateSingleEmail(new EmailAddress(senderName), new EmailAddress(recipient), discussion, null, message);
            var response = await Client.SendEmailAsync(msg);

            if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                Console.WriteLine("Email sent successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to send email. Status code: {response.StatusCode}");
                string responseBody = await response.Body.ReadAsStringAsync();
                Console.WriteLine($"Response body: {responseBody}");
            }
        }
    }
}