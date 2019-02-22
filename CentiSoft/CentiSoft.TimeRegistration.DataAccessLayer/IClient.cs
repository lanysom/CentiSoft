using System.Collections.Generic;
using System.Data;

namespace CentiSoft.TimeRegistration.DataAccessLayer
{
    public interface IClient : IEntity
    {
        IList<ICustomer> Customers { get; set; }
        string Name { get; set; }
        string Token { get; set; }
    }
}