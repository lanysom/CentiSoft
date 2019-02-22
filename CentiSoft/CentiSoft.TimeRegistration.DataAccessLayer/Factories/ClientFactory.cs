using CentiSoft.TimeRegistration.DataAccessLayer.Model;
using System;
using System.Collections.Generic;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Factories
{
    internal sealed class ClientFactory : EntityFactory<IClient>
    {
        public override IClient Create()
        {
            return new Client
            {
                Customers = new List<ICustomer>()
            };
        }

        public override IEnumerable<IClient> GetAll()
        {
            throw new NotImplementedException();
        }

        public override IClient GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
