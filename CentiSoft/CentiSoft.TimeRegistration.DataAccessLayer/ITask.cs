using CentiSoft.TimeReg.Repository.Model;
using System;

namespace CentiSoft.TimeRegistration.DataAccessLayer
{
    public interface ITask : IEntity
    {
        DateTime Created { get; set; }
        string Description { get; set; }
        IDeveloper Developer { get; set; }
        float Duration { get; set; }
        string Name { get; set; }
        IProject Project { get; set; }
    }
}