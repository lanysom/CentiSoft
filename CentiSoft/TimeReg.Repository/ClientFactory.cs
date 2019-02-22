﻿using CentiSoft.TimeReg.Repository.Interface;
using CentiSoft.TimeReg.Repository.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentiSoft.TimeReg.Repository
{
    public sealed class ClientFactory : IEntityFactory<IClient>
    {
        private readonly IConfiguration _config;

        public ClientFactory(IConfiguration config)
        {
            _config = config;
        }

        public IClient Create()
        {
            return new Client
            {
                Customers = new List<ICustomer>()
            };
        }

        public IEnumerable<IClient> GetAll()
        {
            throw new NotImplementedException();
        }

        public IClient GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}