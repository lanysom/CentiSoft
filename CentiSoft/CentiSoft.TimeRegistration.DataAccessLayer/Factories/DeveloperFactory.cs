using CentiSoft.TimeRegistration.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Factories
{
    internal sealed class DeveloperFactory : EntityFactory<IDeveloper>
    {
        public DeveloperFactory(Func<IDbConnection> dbConnectionFactory) : base(dbConnectionFactory)
        {
        }

        public override IDeveloper Create()
        {
            return new Developer(OpenDbConnection)
            {
                Tasks = new List<ITask>()
            };
        }

        public override IEnumerable<IDeveloper> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public override IDeveloper GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        internal IDeveloper GetByTaskId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
