using CentiSoft.TimeReg.Repository;
using CentiSoft.TimeReg.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeReg.Repository.Test
{
    class TaskTests
    {
        private IEntityFactory<ITask> _factory;

        public TaskTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IEntityFactory<ITask>, TaskFactory>();

            var serviceProvider = services.BuildServiceProvider();
            _factory = serviceProvider.GetService<IEntityFactory<ITask>>();
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CreateTaskTest()
        {
            var task = _factory.Create();
            Assert.IsNotNull(task);
            Assert.IsInstanceOf<ITask>(task);
            Assert.Zero(task.Id);
            Assert.IsNull(task.Name);
            Assert.IsNull(task.Description);
            Assert.Zero(task.Duration);
            Assert.IsNull(task.Project);
            Assert.IsNull(task.Developer);
            Assert.AreEqual(DateTime.MinValue, task.Created);
        }
    }
}
