using CentiSoft.TimeReg.Repository;
using CentiSoft.TimeReg.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeReg.Repository.Test
{
    class CustomerTests
    {
        private IEntityFactory<ICustomer> _factory;

        public CustomerTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IEntityFactory<ICustomer>, CustomerFactory>();

            var serviceProvider = services.BuildServiceProvider();
            _factory = serviceProvider.GetService<IEntityFactory<ICustomer>>();
        }

        [Test]
        public void CreateCustomerTest()
        {
            var customer = _factory.Create();
            Assert.IsNotNull(customer);
            Assert.IsInstanceOf<ICustomer>(customer);
            Assert.Zero(customer.Id);
            Assert.IsNull(customer.Name);
            Assert.IsNull(customer.Address);
            Assert.IsNull(customer.Address2);
            Assert.IsNull(customer.Zip);
            Assert.IsNull(customer.City);
            Assert.IsNull(customer.Email);
            Assert.IsNull(customer.Phone);
            Assert.IsNull(customer.Country);
            Assert.IsNull(customer.Client);
            Assert.IsNotNull(customer.Projects, "Projects list is not instantiated");
            Assert.Zero(customer.Projects.Count);
        }

    }
}
