using Colc.BLL.Interface;
using Framework.IoC.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcAdapter
{
    public class Registration
    {
        static Container ct = null;

        private Registration()
        {
            ct = new Container(ContainerOptions.UseDefaultValue);
            //ct.RegisterType<IStudentManager, MsSql>();
            ct.RegisterType<IDiscauntManager, Data>();
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

    public class Data : IDiscauntManager
    {

    public double GetDiscount(string status)
    {
 	    throw new NotImplementedException();
    }
}

    public class AdapterDiscaunt
    {
        private IDiscauntManager source;

        public AdapterDiscaunt(IDiscauntManager powerSource)
        {
            this.source = powerSource;
        }

        public double GetDiscount(string status)
        {
            return this.source.GetDiscount(status);
        }
    }

}
