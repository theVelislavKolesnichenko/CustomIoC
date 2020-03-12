namespace Framework.IoC.ServiceLocator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Framework.IoC.ServiceLocator.Interface;

    /// <summary>
    /// This class is a very simple implementation of service locator.
    /// </summary>
 
    /// <summary>
        /// This property is purely for testing this class.
        /// </summary>
    internal class ServiceLocator : IServiceLocator
    {
        private readonly Dictionary<Type, object> services = new Dictionary<Type, object>();
        private readonly object _lock = new object();

        private bool initialised;

        internal IDictionary<Type, object> Services
        {
            get
            {
                return services;
            }
        }

        public void Set<T>(T service)
        {
            if (!typeof(T).IsInterface)
            {
                throw new ServiceLocatorException("Only interfaces can be registered with instances.");
            }

            lock (((ICollection)services).SyncRoot)
            {
                if (services.ContainsKey(typeof(T)))
                {
                    services[typeof(T)] = service;
                }
                else
                {
                    services.Add(typeof(T), service);
                }
            }
        }

        public void Initialise()
        {
            lock (_lock)
            {
                if (initialised)
                {
                    throw new ServiceLocatorException("Service locator can only be initialise once.");
                }

                initialised = true;
            }
        }

        public T Get<T>()
        {
            lock (((ICollection)services).SyncRoot)
            {
                if (!services.ContainsKey(typeof(T)))
                {
                    throw new ServiceLocatorException("Service not found.");
                }

                var instance = services[typeof(T)];

                return (T)instance;
            }
        }
    }
}
