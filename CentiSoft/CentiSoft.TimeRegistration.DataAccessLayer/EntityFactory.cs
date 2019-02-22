using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CentiSoft.TimeRegistration.DataAccessLayer
{
    public abstract class EntityFactory<TEntity>
    {
        public static EntityFactory<TEntity> Use()
        {
            throw new NotImplementedException();
        }

        public EntityFactory<TEntity> WithDatabaseConnection(Func<IDbConnection> connectionFactory)
        {
            throw new NotImplementedException();
        }

        public abstract TEntity GetById(int id);

        public abstract IEnumerable<TEntity> GetAll();

        public abstract TEntity Create();
    }
}
