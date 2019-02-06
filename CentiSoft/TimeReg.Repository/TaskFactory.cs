using CentiSoft.TimeReg.Repository.Interface;
using CentiSoft.TimeReg.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentiSoft.TimeReg.Repository
{
    public sealed class TaskFactory : IEntityFactory<ITask>
    {
        public ITask Create()
        {
            return new Task();
        }

        public IEnumerable<ITask> GetAll()
        {
            throw new NotImplementedException();
        }

        public ITask GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
