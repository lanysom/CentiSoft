using CentiSoft.TimeRegistration.DataAccessLayer.Model;
using System.Collections.Generic;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Factories
{
    internal sealed class DeveloperFactory : EntityFactory<IDeveloper>
    {
        public override IDeveloper Create()
        {
            return new Developer(OpenDbConnection)
            {
                Tasks = new List<ITask>()
            };
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
