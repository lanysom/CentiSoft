using System.Collections.Generic;

namespace CentiSoft.TimeReg.Repository.Interface
{
    public interface IDeveloper : IEntity
    {
        string Email { get; set; }
        string Name { get; set; }
        IList<ITask> Tasks { get; set; }
    }
}