namespace Framework.IoC.ServiceLocator
{
    using System;
    
    /// <summary>
    /// This custom exception to indicate <see cref="ServiceLocator"/> fatal errors.
    /// </summary>
    public class ServiceLocatorException : Exception
    {
        public ServiceLocatorException(string message)
            : base(message)
        {
        }
    }
}
