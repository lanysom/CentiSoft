using System.Collections.Generic;

namespace CentiSoft.TimeRegistration.DataAccessLayer
{
    public interface ICustomer : IEntity
    {
        string Address { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        IClient Client { get; set; }
        string Country { get; set; }
        string Email { get; set; }
        string Name { get; set; }
        string Phone { get; set; }
        IList<IProject> Projects { get; set; }
        string Zip { get; set; }
    }
}