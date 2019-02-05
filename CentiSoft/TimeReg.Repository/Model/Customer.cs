using CentiSoft.TimeReg.Repository.Interface;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CentiSoft.TimeReg.Repository.Model
{
    class Customer : ICustomer
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IClient Client { get; set; }
        public IList<IProject> Projects { get; set; }

        public bool Delete(string connStr)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(string connStr)
        {
            throw new System.NotImplementedException();
        }
    }
}
