using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using CI_API.Models.ViewModels;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace CI_API.Common
{
    public class CommonMethods
    {
        private IConfiguration _configuration;
        public CommonMethods(IConfiguration config )
        {
            _configuration=config;
        }
        public bool TestMethod()
        {
            return true;
        }
        public bool SendEmail(SendEmailModel sendEmail)
        {
            var email = new MimeMessage();
            var from = _configuration["EmailSettings:From"];
            var to = sendEmail.To;
            var server = _configuration["EmailSettings:SmtpServer"];
            var password = _configuration["EmailSettings:Password"];
            email.From.Add(new MailboxAddress("CI-Platform",from ));
            email.To.Add(new MailboxAddress(to,to));
            email.Subject=sendEmail.Subject;
            email.Body=new TextPart(MimeKit.Text.TextFormat.Html) { 
           Text=String.Format(sendEmail.Body)
            };
            using (var client = new SmtpClient())
            {


                try
                {
                    client.Connect(server, 465, true);
                    client.Authenticate(from, password);
                    client.Send(email);
                }
                catch (Exception e)
                {
                    return false;
                    throw;
                }

                finally
                {
                    client.Disconnect(true);
                }
                return true;
            }
        }
    }
}
