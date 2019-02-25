using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Test
{
    [TestClass]
    public class ProjectTests
    {
        private EntityFactory<IProject> _factory;

        [TestInitialize]
        public void Setup()
        {
            _factory = EntityFactory.Use<IProject>(() =>
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
            Assert.IsInstanceOfType(test, typeof(IProject));
        }

        [TestMethod]
        public void GetAllTest()
        {            
            var projects = _factory.GetAll();

            Assert.IsNotNull(projects);
            Assert.IsInstanceOfType(projects, typeof(IEnumerable<IProject>));
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var test = _factory.GetById(0);
            Assert.IsNull(test);
        }
    }
}
