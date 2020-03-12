using Framework.IoC.DependencyInjection;
using SendEmail.BLL;
using SendEmail.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class Registration
    {
        static Container ct = null;

        private Registration()
        {
            ct = new Container(ContainerOptions.UseDefaultValue);
            ct.RegisterType<IMessageManager, MassageSend>();
        }

        public static Container Instance
        {
            get
            {
                if (ct == null)
                {
                    new Registration();
                }
                return ct;
            }
        }
    }

    public class AdaperSendMessage
    {
        private IMessageManager source;

        public AdaperSendMessage(IMessageManager powerSource)
        {
            this.source = powerSource;
        }

        public void SendMassage(string subject, string msg)
        {
            this.source.SendMassage(subject, msg);
        }

    }
}
