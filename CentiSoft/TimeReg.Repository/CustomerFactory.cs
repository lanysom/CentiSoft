using CentiSoft.TimeReg.Repository.Interface;
using CentiSoft.TimeReg.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentiSoft.TimeReg.Repository
{
    public sealed class CustomerFactory : IEntityFactory<ICustomer>
    {
        public ICustomer Create()
        {
            return new Customer
            {
                Projects = new List<IProject>()
            };
        }

        public IEnumerable<ICustomer> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICustomer GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
