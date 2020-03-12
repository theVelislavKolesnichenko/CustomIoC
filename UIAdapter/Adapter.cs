using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentSystem.BLL;
using StudentSystem.BLL.Interface;
using Framework.IoC.ServiceLocator;

namespace UIAdapter
{
    public class Adapter
    {
        public Adapter()
        {
            var test = new StudentLogic();
            Locator.SetInstance<IStudentLogic>(test);
        }
    }
}
