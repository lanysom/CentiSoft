using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Model
{
    internal abstract class EntityBase
    {
        public Func<IDbConnection> OpenDbConnection { get; }

        protected EntityBase(Func<IDbConnection> connectionFactory)
        {
            OpenDbConnection = connectionFactory;
        }
    }
}
