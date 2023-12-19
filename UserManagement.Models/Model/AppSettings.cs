using Microsoft.EntityFrameworkCore;

namespace UserManagement.Models.Model
{
    public class AppSettings 
    {
        public EmailSetting EmailSetting { get; set; }
    }

    public class EmailSetting
    {
        public string AppEmail { get; set; }
        public string SmtpClient { get; set; }
        public string Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EnableSsl { get; set; }
        public string SenderName { get; set; }
    }
}
