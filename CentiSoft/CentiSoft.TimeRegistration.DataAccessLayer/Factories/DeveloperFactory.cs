using System.Collections.Generic;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Factories
{
    public sealed class DeveloperFactory : EntityFactory<IDeveloper>
    {
        public override IDeveloper Create()
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<IDeveloper> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public override IDeveloper GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
