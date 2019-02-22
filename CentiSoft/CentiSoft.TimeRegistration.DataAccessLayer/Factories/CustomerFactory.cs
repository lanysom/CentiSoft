using System;
using System.Collections.Generic;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Factories
{
    internal sealed class CustomerFactory : EntityFactory<ICustomer>
    {
        public override ICustomer Create()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ICustomer> GetAll()
        {
            throw new NotImplementedException();
        }

        public override ICustomer GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
