using System.Collections.Generic;
using System.Data;

namespace CentiSoft.TimeReg.Repository.Interface
{
    public interface IClient : IEntity
    {
        IList<ICustomer> Customers { get; set; }
        string Name { get; set; }
        string Token { get; set; }
    }
}