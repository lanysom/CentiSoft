using CentiSoft.TimeReg.Repository.Interface;
using CentiSoft.TimeReg.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentiSoft.TimeReg.Repository
{
    public class DeveloperFactory : IEntityFactory<IDeveloper>
    {
        public IDeveloper Create()
        {
            return new Developer
            {
                Tasks = new List<ITask>()
            };
        }

        public IEnumerable<IDeveloper> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDeveloper GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
