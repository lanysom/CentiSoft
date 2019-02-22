using CentiSoft.TimeRegistration.DataAccessLayer.Factories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CentiSoft.TimeRegistration.DataAccessLayer
{
    /// <summary>
    /// Describes a factory for creating or retrieving entities from a database
    /// </summary>
    /// <typeparam name="TEntity">The interface on which to recieve an entity</typeparam>
    public abstract class EntityFactory<TEntity>
    {
        protected static Dictionary<string, EntityFactory<TEntity>> _factories = new Dictionary<string, EntityFactory<TEntity>>();
        protected Func<IDbConnection> OpenDbConnection { get; private set; }

        public EntityFactory(Func<IDbConnection> dbConnectionFactory)
        {
            OpenDbConnection = dbConnectionFactory;
        }

        /// <summary>
        /// Creates a factory for the specified interface
        /// </summary>
        /// <returns></returns>
        public static EntityFactory<TEntity> Use(Func<IDbConnection> dbConnectionFactory)
        {
            if (!_factories.ContainsKey(typeof(TEntity).Name))
            {
                switch (typeof(TEntity).Name)
                {
                    case "IProject":
                        _factories.Add(typeof(TEntity).Name, new ProjectFactory(dbConnectionFactory) as EntityFactory<TEntity>);
                        break;
                    case "ITask":
                        _factories.Add(typeof(TEntity).Name, new TaskFactory(dbConnectionFactory) as EntityFactory<TEntity>);
                        break;
                    case "ICustomer":
                        _factories.Add(typeof(TEntity).Name, new CustomerFactory(dbConnectionFactory) as EntityFactory<TEntity>);
                        break;
                    case "IDeveloper":
                        _factories.Add(typeof(TEntity).Name, new DeveloperFactory(dbConnectionFactory) as EntityFactory<TEntity>);
                        break;
                    case "IClient":
                        _factories.Add(typeof(TEntity).Name, new ClientFactory(dbConnectionFactory) as EntityFactory<TEntity>);
                        break;
                    default:
                        throw new NotImplementedException("A factory for the requested interface is not implemented");
                }
            }

            return _factories[typeof(TEntity).Name];
        }

        /// <summary>
        /// Adds a database connection factory method to the entity factory
        /// </summary>
        /// <param name="connectionFactory">A database connection factory method</param>
        public EntityFactory<TEntity> WithDatabaseConnection(Func<IDbConnection> connectionFactory)
        {
            if (OpenDbConnection == null)
            {
                OpenDbConnection = connectionFactory;
            }
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
