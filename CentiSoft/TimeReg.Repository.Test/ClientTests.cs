using CentiSoft.TimeReg.Repository;
using CentiSoft.TimeReg.Repository.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TimeReg.Repository.Test
{
    class ClientTests
    {
        private IEntityFactory<IClient> _factory;

        public ClientTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IEntityFactory<IClient>, ClientFactory>();
            services.AddSingleton<IConfiguration>(s =>
            {
                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
                return config.Build();
            });

            var serviceProvider = services.BuildServiceProvider();
            _factory = serviceProvider.GetService<IEntityFactory<IClient>>();
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CreateClientTest()
        {
            var client = _factory.Create();
            Assert.IsNotNull(client);
            Assert.IsInstanceOf<IClient>(client);
            Assert.Zero(client.Id);
            Assert.IsNull(client.Name);
            Assert.IsNull(client.Token);
            Assert.IsNotNull(client.Customers, "Customers list is not instantiated");
            Assert.Zero(client.Customers.Count);
        }
    }
}
