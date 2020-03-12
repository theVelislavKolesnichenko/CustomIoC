using SendEmail.Data;
using SendEmail.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.BLL.Interface
{
    public interface IMessageManager
    {
        EmailRepository repository { get; }
        string EmailTo { get; set; }
        string EmailFrom { get; set; }
        string Password { get; set; }
        bool SendMassage(string subject, string message);
    }
}
