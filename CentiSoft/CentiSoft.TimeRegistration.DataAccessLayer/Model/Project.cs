using System;
using System.Collections.Generic;
using System.Data;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Model
{
    internal class Project : EntityBase, IProject
    {
        public Project(Func<IDbConnection> connectionFactory) : base(connectionFactory)
        {
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public ICustomer Customer { get; set; }
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
