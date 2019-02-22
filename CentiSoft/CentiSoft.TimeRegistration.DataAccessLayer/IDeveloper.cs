using System.Collections.Generic;

namespace CentiSoft.TimeRegistration.DataAccessLayer
{
    public interface IDeveloper : IEntity
    {
        string Email { get; set; }
        string Name { get; set; }
        IList<ITask> Tasks { get; set; }
    }
}