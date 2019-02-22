using System;
using System.Collections.Generic;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Factories
{
    public sealed class ClientFactory : EntityFactory<IClient>
    {
        public override IClient Create()
        {
            throw new NotImplementedException();
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
