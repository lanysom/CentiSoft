using CentiSoft.TimeReg.Repository;
using CentiSoft.TimeReg.Repository.Interface;
using NUnit.Framework;
using System;

namespace Tests
{
    public class EntityFactoryTest
    {
        string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CentiSoft;Integrated Security=True;Pooling=False";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateTaskTest()
        {
            var task = EntityFactory.Create<ITask>();
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

        [Test]
        public void CreateCustomerTest()
        {
            var customer = EntityFactory.Create<ICustomer>();
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

        [Test]
        public void CreateClientTest()
        {
            var client = EntityFactory.Create<IClient>();
            Assert.IsNotNull(client);
            Assert.IsInstanceOf<IClient>(client);
            Assert.Zero(client.Id);
            Assert.IsNull(client.Name);
            Assert.IsNull(client.Token);
            Assert.IsNotNull(client.Customers, "Customers list is not instantiated");
            Assert.Zero(client.Customers.Count);
        }

        [Test]
        public void CreateDeveloperTest()
        {
            var developer = EntityFactory.Create<IDeveloper>();
            Assert.IsNotNull(developer);
            Assert.IsInstanceOf<IDeveloper>(developer);
            Assert.Zero(developer.Id);
            Assert.IsNull(developer.Name);
            Assert.IsNull(developer.Email);
            Assert.IsNotNull(developer.Tasks, "Tasks list is not instantiated");
            Assert.Zero(developer.Tasks.Count);
        }

        [Test]
        public void CreateProjectTest()
        {
            var project = EntityFactory.Create<IProject>();
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