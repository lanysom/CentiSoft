using CentiSoft.TimeRegistration.DataAccessLayer.Factories;
using CentiSoft.TimeRegistration.DataAccessLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CentiSoft.TimeRegistration.DataAccessLayer
{
    public abstract class EntityFactory
    {
        protected static Dictionary<string, EntityFactory> _factories = new Dictionary<string, EntityFactory>();
        private readonly Func<IDbConnection> _dbConnectionFactory;

        protected EntityFactory(Func<IDbConnection> dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        protected IDbConnection OpenDbConnection()
        {
            var conn = _dbConnectionFactory();

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            return conn;
        }

        /// <summary>
        /// Gets the abstract factory for an entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbConnectionFactory">The factory method for opening a connection to the database</param>
        /// <returns></returns>
        public static EntityFactory<TEntity> Use<TEntity>(Func<IDbConnection> dbConnectionFactory)
        {
            if (!_factories.ContainsKey(typeof(TEntity).Name))
            {
                switch (typeof(TEntity).Name)
                {
                    case "IProject":
                        _factories.Add(typeof(TEntity).Name, new ProjectFactory(dbConnectionFactory));
                        break;
                    case "ITask":
                        _factories.Add(typeof(TEntity).Name, new TaskFactory(dbConnectionFactory));
                        break;
                    case "ICustomer":
                        _factories.Add(typeof(TEntity).Name, new CustomerFactory(dbConnectionFactory));
                        break;
                    case "IDeveloper":
                        _factories.Add(typeof(TEntity).Name, new DeveloperFactory(dbConnectionFactory));
                        break;
                    case "IClient":
                        _factories.Add(typeof(TEntity).Name, new ClientFactory(dbConnectionFactory));
                        break;
                    default:
                        throw new NotImplementedException("An abstract factory class for the requested interface is not implemented");
                }
            }
            return _factories[typeof(TEntity).Name] as EntityFactory<TEntity>;
        }
    }

    /// <summary>
    /// Describes a factory for creating or retrieving entities from a database
    /// </summary>
    /// <typeparam name="TEntity">The interface on which to recieve an entity</typeparam>
    public abstract class EntityFactory<TEntity> : EntityFactory
    {
        protected readonly string SelectSql;
        
        protected EntityFactory(Func<IDbConnection> dbConnectionFactory, string selectSql) : base (dbConnectionFactory)
        {
            SelectSql = selectSql;
        }

        /// <summary>
        /// Gets an entity from the database
        /// </summary>
        /// <param name="id">The identity of the requested entity</param>
        /// <returns></returns>
        public virtual TEntity GetById(int id)
        {
            using (var conn = OpenDbConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"{SelectSql} WHERE Id = @id;";
                    cmd.AddParameter("@id", id);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return Map(reader);
                    }
                    return default(TEntity);
                }
            }
        }

        /// <summary>
        /// Get all entities from the database
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            using (var conn = OpenDbConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = SelectSql;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        yield return Map(reader);
                    }
                }
            }
        }

        /// <summary>
        /// Creates a new instance of an entity
        /// </summary>
        /// <returns></returns>
        public abstract TEntity Create();

        /// <summary>
        /// Maps an IDataReader to the entity of the factory
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected abstract TEntity Map(IDataReader reader);
    }
}
