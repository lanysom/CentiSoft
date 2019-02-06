using CentiSoft.TimeReg.Repository;
using CentiSoft.TimeReg.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeReg.Repository.Test
{
    class DeveloperTests
    {
        private IEntityFactory<IDeveloper> _factory;

        public DeveloperTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IEntityFactory<IDeveloper>, DeveloperFactory>();

            var serviceProvider = services.BuildServiceProvider();
            _factory = serviceProvider.GetService<IEntityFactory<IDeveloper>>();
        }

        [Test]
        public void CreateDeveloperTest()
        {
            var developer = _factory.Create();
            Assert.IsNotNull(developer);
            Assert.IsInstanceOf<IDeveloper>(developer);
            Assert.Zero(developer.Id);
            Assert.IsNull(developer.Name);
            Assert.IsNull(developer.Email);
            Assert.IsNotNull(developer.Tasks, "Tasks list is not instantiated");
            Assert.Zero(developer.Tasks.Count);
        }

    }
}
