namespace AuthenticationWebApi.Models
{
    public class EmailConfiguration
    {
        public int SmtpPort { get; set; } = 465;
        public string SmtpServer { get; set; } = "smtp.mail.ru";
        public string SmtpUsername { get; set; } = "";
        public string SmtpPassword { get; set; } = "";
        public string FromName { get; set; } = "Spotty Motor";
        public string FromAddress { get; set; } = "";
    }
}
