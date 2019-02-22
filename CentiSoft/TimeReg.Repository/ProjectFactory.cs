using CentiSoft.TimeReg.Repository.Interface;
using CentiSoft.TimeReg.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentiSoft.TimeReg.Repository
{
    public sealed class ProjectFactory : IEntityFactory<IProject>
    {
        public IProject Create()
        {
            return new Project
            {
                Tasks = new List<ITask>()
            };
        }

        public IEnumerable<IProject> GetAll()
        {
            throw new NotImplementedException();
        }

        public IProject GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
