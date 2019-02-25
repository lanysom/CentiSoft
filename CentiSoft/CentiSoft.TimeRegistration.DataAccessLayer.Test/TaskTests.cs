using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Test
{
    [TestClass]
    public class TaskTests
    {
        private EntityFactory<ITask> _factory;

        [TestInitialize]
        public void Setup()
        {
            _factory = EntityFactory.Use<ITask>(() =>
            {
                var conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CentiSoft;Integrated Security=True;Pooling=False");
                conn.Open();
                return conn;
            });
        }

        [TestMethod]
        public void CreateTest()
        {
            var task = _factory.Create();

            Assert.IsNotNull(task);
            Assert.IsInstanceOfType(task, typeof(ITask));
            Assert.AreEqual(0, task.Id);            
        }

        [TestMethod]
        public void GetAllTest()
        {
            var test = _factory.GetAll();

            Assert.IsNotNull(test);
            Assert.IsInstanceOfType(test, typeof(IEnumerable<ITask>));
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var test = _factory.GetById(0);
            Assert.IsNull(test);
        }
    }
}
