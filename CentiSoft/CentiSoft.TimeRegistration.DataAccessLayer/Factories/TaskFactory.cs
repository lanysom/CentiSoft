using CentiSoft.TimeRegistration.DataAccessLayer.Model;
using System;
using System.Collections.Generic;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Factories
{
    internal sealed class TaskFactory : EntityFactory<ITask>
    {
        public override ITask Create()
        {
            return new Task(OpenDbConnection);
        }

        public override IEnumerable<ITask> GetAll()
        {
            throw new NotImplementedException();
        }

        public override ITask GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
