using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.IoC.ServiceLocator.Interface
{
    /// <summary>
    /// This interface provides the abstraction for a service locator.
    /// </summary>
    interface IServiceLocator
    {
        void Set<T>(T service);

        void Initialise();

        T Get<T>();
    }
}
