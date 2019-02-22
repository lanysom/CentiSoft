using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Linq;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Test
{
    [TestClass]
    public class ProjectTests
    {
        [TestMethod]
        public void GetAllTest()
        {
            var factory = EntityFactory<IProject>.Use(() =>
            {
                var conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CentiSoft;Integrated Security=True;Pooling=False");
                conn.Open();
                return conn;
            });

            var projects = factory.GetAll().ToList();
        }
    }
}
