using CentiSoft.TimeRegistration.DataAccessLayer.Model;
using System.Collections.Generic;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Factories
{
    internal sealed class ProjectFactory : EntityFactory<IProject>
    {
        public override IProject Create()
        {
            return new Project(OpenDbConnection)
            {
                Tasks = new List<ITask>()
            };
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
