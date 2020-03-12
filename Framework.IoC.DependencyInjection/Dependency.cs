using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Framework.IoC.DependencyInjection
{
    public class Dependency
    {
        public ConstructorInfo Constructor { get; set; }
        public ParameterInfo[] Parameters { get; set; }
    }
}
