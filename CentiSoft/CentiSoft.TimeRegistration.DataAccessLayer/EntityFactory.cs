using CentiSoft.TimeRegistration.DataAccessLayer.Factories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CentiSoft.TimeRegistration.DataAccessLayer
{
    /// <summary>
    /// Describes a factory for creating or retrieving entities from a database
    /// </summary>
    /// <typeparam name="TEntity">The interface on which to recieve an entity</typeparam>
    public abstract class EntityFactory<TEntity>
    {
        protected Func<IDbConnection> OpenDbConnection { get; private set; }

        /// <summary>
        /// Creates a factory for the specified interface
        /// </summary>
        /// <returns></returns>
        public static EntityFactory<TEntity> Use()
        {
            var entityType = typeof(TEntity);

            if (entityType is IClient)
            {
                return new ClientFactory() as EntityFactory<TEntity>;
            }
            else if (entityType is ICustomer)
            {
                return new CustomerFactory() as EntityFactory<TEntity>;
            }
            else if (entityType is IDeveloper)
            {
                return new DeveloperFactory() as EntityFactory<TEntity>;
            }
            else if (entityType is IProject)
            {
                return new ProjectFactory() as EntityFactory<TEntity>;
            }
            else if (entityType is ITask)
            {
                return new TaskFactory() as EntityFactory<TEntity>;
            }
            else
            {
                throw new NotImplementedException("A factory for the requested interface is not implemented");
            }
        }

        /// <summary>
        /// Adds a database connection factory to the entity factory
        /// </summary>
        /// <param name="connectionFactory">A database connection factory method</param>
        public EntityFactory<TEntity> WithDatabaseConnection(Func<IDbConnection> connectionFactory)
        {
            OpenDbConnection = connectionFactory;
            return this;
        }

        /// <summary>
        /// Gets an entity from the database
        /// </summary>
        /// <param name="id">The identity of the requested entity</param>
        /// <returns></returns>
        public abstract TEntity GetById(int id);

        /// <summary>
        /// Get all entities from the database
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Creates a new instance of an entity
        /// </summary>
        /// <returns></returns>
        public abstract TEntity Create();
    }
}
