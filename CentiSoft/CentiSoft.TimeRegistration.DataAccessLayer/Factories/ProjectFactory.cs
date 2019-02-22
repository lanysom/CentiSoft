using System.Collections.Generic;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Factories
{
    public sealed class ProjectFactory : EntityFactory<IProject>
    {
        public override IProject Create()
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<IProject> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public override IProject GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
