using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colc.BLL.Interface
{
    public interface IDiscauntManager
    {
        double GetDiscount(string status);
    }
}
