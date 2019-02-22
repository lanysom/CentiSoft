﻿using CentiSoft.TimeReg.Repository.Interface;
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

        public IClient Create(string name, string token)
        {
            var client = new Client
            {
                Name = name,
                Token = token,
            };
            
            return client;
        }

        public void Delete(string connStr)
        {
            throw new NotImplementedException();
        }

        public void Update(string connStr)
        {
            throw new NotImplementedException();
        }
    }
}
