using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendEmail.BLL.Interface;

using SendEmail.Data.Interface;
using SendEmail.Data;
using SendEmail.Data.Model;

namespace SendEmail.BLL
{
    public class MassageSend : IMessageManager
    {
        public EmailRepository repository { get { return new SendEmail.Data.EmailRepository(); } }

        public string EmailTo { get; set; }
        public string EmailFrom { get; set; }
        public string Password { get; set; }

        private string DefaultPassword { get { return "equal86rites"; } }
        private string DefaultEmail { get { return "kolesnichenko.velislav@hotmail.com"; } }

        //public MassageSend(string emailTo, string emailFrom, string password)
        //{
        //    this.EmailTo = emailTo;
        //    this.EmailFrom = emailFrom;
        //    this.Password = password;
        //}

        //public MassageSend(IEmailRepository repository)
        //{
        //    this.repository = repository;
        //}

        public bool SendMassage(string subject, string message)
        {
            bool succsessfull = false; 
            //try
            //{
                var users = repository.GetPoints();

                for (int i = 0; i < users.Count; i++)
                {
                    EmailTo = users[i].Email;
                    EmailFrom = string.IsNullOrEmpty(EmailFrom) ? DefaultEmail : EmailFrom;
                    Password = string.IsNullOrEmpty(Password) ? DefaultPassword : Password;
                    
                    SendEmail.BLL.SendEmailService.ISendEmail ee = new SendEmail.BLL.SendEmailService.SendEmailClient();
                    ee.Send(EmailFrom, Password, EmailTo, subject, message);
                    succsessfull = true;
                }
            //}
            //catch 
            //{
            //    succsessfull = false;
            //}

            return succsessfull;
        }

        //static void Main(string[] args)
        //{
        //    IMessageManager massage = new MassageSend("vili_mon@abv.bg", "kolesnichenko.velislav@hotmail.com", "equal86rites");

        //    bool sucssefull = massage.SendMassage("Test mail", "TEST MAIL");
        //}
    }
}
