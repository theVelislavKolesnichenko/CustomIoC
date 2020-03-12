using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendEmail.BLL.Interface;
using SendEmail.BLL;
using Framework.IoC.DependencyInjection;

using SendEmail.Data.Interface;
using SendEmail.BLL.Interface;
using Adapter;

namespace SentEmail.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {

            char ch;
            do {
                Console.Clear();
                Console.WriteLine("Start Send Email with press S key");

                ch = Convert.ToChar(Console.ReadLine());

            } while (ch != 'S' && ch != 's');
            
            var conteiner = Registration.Instance;

            var instance = conteiner.Resolve<AdaperSendMessage>();

            instance.SendMassage("Test mail", "TEST MAIL");

        }
    }
}
