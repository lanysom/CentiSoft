using System;
using System.Collections.Generic;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Model
{
    class Client : IClient
    {
        public int Id { get; private set; }
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
