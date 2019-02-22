using System;
using System.Collections.Generic;
using System.Data;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Model
{
    internal class Client : EntityBase, IClient
    {
        public Client(Func<IDbConnection> connectionFactory) : base(connectionFactory)
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public IList<ICustomer> Customers { get; set; }

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
