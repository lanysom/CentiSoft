using System;
using System.Collections.Generic;
using System.Data;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Model
{
    internal class Customer : EntityBase, ICustomer
    {
        public Customer(Func<IDbConnection> connectionFactory) : base(connectionFactory)
        {
        }

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

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
