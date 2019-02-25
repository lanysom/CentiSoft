using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Test
{
    [TestClass]
    public class ClientTests
    {
        private EntityFactory<IClient> _factory;

        [TestInitialize]
        public void Setup()
        {
            _factory = EntityFactory.Use<IClient>(() =>
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
            Assert.IsInstanceOfType(test, typeof(IClient));

        }

        [TestMethod]
        public void GetAllTest()
        {
            var clients = _factory.GetAll();

            Assert.IsNotNull(clients);
            Assert.IsInstanceOfType(clients, typeof(IEnumerable<IClient>));
        }
    }
}
