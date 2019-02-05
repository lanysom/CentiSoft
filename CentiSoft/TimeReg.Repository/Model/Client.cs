using CentiSoft.TimeReg.Repository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CentiSoft.TimeReg.Repository.Model
{
    class Client : IClient
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public IList<ICustomer> Customers { get; set; }

        public IClient Create(string name, string token)
        {
            var client = new Client
            {
                Name = name,
                Token = token,
            };
            
            return client;
        }

        public bool Delete(string connStr)
        {
            throw new NotImplementedException();
        }

        public bool Update(string connStr)
        {



            return false;
        }
    }
}
