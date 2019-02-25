using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Test
{
    [TestClass]
    public class DeveloperTests
    {
        private EntityFactory<IDeveloper> _factory;

        [TestInitialize]
        public void Setup()
        {
            _factory = EntityFactory.Use<IDeveloper>(() =>
            {
                var conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CentiSoft;Integrated Security=True;Pooling=False");
                conn.Open();
                return conn;
            });

        }

        [TestMethod]
        public void CreateTest()
        {
            var test = _factory.Create();

            Assert.IsNotNull(test);
            Assert.IsInstanceOfType(test, typeof(IDeveloper));
        }

        [TestMethod]
        public void GetAllTest()
        {
            var test = _factory.GetAll();

            Assert.IsNotNull(test);
            Assert.IsInstanceOfType(test, typeof(IEnumerable<IDeveloper>));
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var test = _factory.GetById(0);
            Assert.IsNull(test);
        }
    }
}
