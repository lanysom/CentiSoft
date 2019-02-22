using System;
using System.Collections.Generic;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Factories
{
    public sealed class TaskFactory : EntityFactory<ITask>
    {
        public override ITask Create()
        {
            throw new NotImplementedException();
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
