using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Test
{
    [TestClass]
    public class CustomerTests
    {
        private EntityFactory<ICustomer> _factory;

        [TestInitialize]
        public void Setup()
        {
            _factory = EntityFactory.Use<ICustomer>(() =>
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
            Assert.IsInstanceOfType(test, typeof(ICustomer));
        }

        [TestMethod]
        public void GetAllTest()
        {
            var test = _factory.GetAll();

            Assert.IsNotNull(test);
            Assert.IsInstanceOfType(test, typeof(IEnumerable<ICustomer>));
        }
    }
}
