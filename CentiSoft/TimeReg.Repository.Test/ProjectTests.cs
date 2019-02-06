using CentiSoft.TimeReg.Repository;
using CentiSoft.TimeReg.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeReg.Repository.Test
{
    class ProjectTests
    {
        private IEntityFactory<IProject> _factory;

        public ProjectTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IEntityFactory<IProject>, ProjectFactory>();

            var serviceProvider = services.BuildServiceProvider();
            _factory = serviceProvider.GetService<IEntityFactory<IProject>>();
        }

        [Test]
        public void CreateProjectTest()
        {
            var project = _factory.Create();
            Assert.IsNotNull(project);
            Assert.IsInstanceOf<IProject>(project);
            Assert.Zero(project.Id);
            Assert.IsNull(project.Name);
            Assert.AreEqual(DateTime.MinValue, project.DueDate);
            Assert.IsNull(project.Customer);
            Assert.IsNotNull(project.Tasks, "Tasks list is not instantiated");
            Assert.Zero(project.Tasks.Count);
        }
    }
}
