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
        [TestMethod]
        public void GetAllTest()
        {
            var factory = EntityFactory<ITask>.Use(() =>
            {
                var conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CentiSoft;Integrated Security=True;Pooling=False");
                conn.Open();
                return conn;
            });


            var test = factory.GetAll().ToList();

        }
    }
}
