using System;
using System.Collections.Generic;

namespace CentiSoft.TimeReg.Repository.Interface
{
    public interface IProject : IEntity
    {
        ICustomer Customer { get; set; }
        DateTime DueDate { get; set; }
        string Name { get; set; }
        IList<ITask> Tasks { get; set; }
    }
}