namespace Framework.DataAccess.Interface
{
    using System;
    using System.Data.Entity;

    /// <summary>
    /// IUnitOfWork interface.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Get or set current context
        /// </summary> 
        DbContext Context { get; set; }

        /// <summary>
        /// Enable/Disable entity option for lazy loading 
        /// </summary>
        bool LazyLoadingEnabled { get; set; }

        /// <summary>
        /// Check all entities for IUnitState interface implementation.
        /// </summary>
        bool HasUnitStateImplemented { get; }

        /// <summary>
        /// Saves all pending context changes.
        /// </summary>   
        int Commit();

        /// <summary>
        /// Apply changes for all modified or added entities.
        /// </summary>
        void ApplyChanges();
    }
}
