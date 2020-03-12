using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEmailConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TestEmailConsole.SendEmailService.ISendEmail ee = new TestEmailConsole.SendEmailService.SendEmailClient();
            ee.Send("kolesnichenko.velislav@hotmail.com", "equal86rites", "vili_mon@abv.bg", "Web Service", "Hello, I'm web service!");
        }
    }
}
