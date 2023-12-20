using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UserManagement.Models.Model;
using UserManagement.Model.Response;
using UserManagement.Services.Interfaces;
using UserManagement.Models.Model.Request;
using UserManagement.Model;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace UserManagement.Services
{
    public class EmailService : IEmailService
    {
        private readonly UserDBContext _context;
        private readonly AppSettings _appSettings;

        public EmailService(UserDBContext userDBContext,
                            AppSettings appSettings) 
        {
            _context = userDBContext;
            _appSettings = appSettings;
        }

        public async Task<Boolean> SendEmailAsync(string id, string oldPas, string Email)
        {
            try
            {
                // create email
                using var message = new MimeMessage();
                var sender = new MailboxAddress(_appSettings.EmailSetting.SenderName, _appSettings.EmailSetting.AppEmail);
                message.From.Add(sender);
                var to = new MailboxAddress(Email, Email);
                message.To.Add(to);
                message.Subject = "Temperory Password";

                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = "The Temperory Password for the user " + id + "is given in this EMail. please use this email to setup your Account" + oldPas
                };

                // Add attachments if needed
                // bodyBuilder.Attachments.Add("path_to_attachment_file");

                message.Body = bodyBuilder.ToMessageBody();


                using var smtpClient = new SmtpClient();
                await smtpClient.ConnectAsync(
                    _appSettings.EmailSetting.SmtpClient,
                    int.Parse(_appSettings.EmailSetting.Port),
                    SecureSocketOptions.StartTlsWhenAvailable);

                // Note: If your SMTP server requires authentication, uncomment the following lines
                await smtpClient.AuthenticateAsync(_appSettings.EmailSetting.UserName, _appSettings.EmailSetting.Password);
                await smtpClient.SendAsync(message); // send the message
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }


    }
}
