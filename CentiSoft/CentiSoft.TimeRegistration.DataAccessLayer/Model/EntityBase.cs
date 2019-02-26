using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Model
{
    internal abstract class EntityBase
    {
        private readonly Func<IDbConnection> _connectionFactory;
        
        protected EntityBase(Func<IDbConnection> connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        protected IDbConnection OpenDbConnection()
        {
            var conn = _connectionFactory();

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            return conn;
        }
    }
}
