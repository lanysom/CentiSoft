using System;
using System.Collections.Generic;
using System.Data;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Model
{
    internal class Developer : EntityBase, IDeveloper
    {
        public Developer(Func<IDbConnection> connectionFactory) : base(connectionFactory)
        {
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<ITask> Tasks { get; set; }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
