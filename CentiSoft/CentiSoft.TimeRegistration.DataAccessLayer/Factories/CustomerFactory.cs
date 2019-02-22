using CentiSoft.TimeRegistration.DataAccessLayer.Helpers;
using CentiSoft.TimeRegistration.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Factories
{
    internal sealed class CustomerFactory : EntityFactory<ICustomer>
    {
        public CustomerFactory(Func<IDbConnection> dbConnectionFactory) : base(dbConnectionFactory)
        {
        }

        public override ICustomer Create()
        {
            return new Customer(OpenDbConnection)
            {
                Projects = new List<IProject>()
            };
        }

        public const int ID = 0;
        public const int NAME = 1;
        public const int ADDRESS = 2;
        public const int ADDRESS2 = 3;
        public const int ZIP = 4;
        public const int CITY = 5;
        public const int COUNTRY = 6;
        public const int EMAIL = 7;
        public const int PHONE = 8;

        private const string SELECT_SQL = "SELECT c.Id, c.Name, c.Address, c.Address2, c.Zip, c.City, c.Country, c.Email, c.Phone, c.ClientId " +
                                          "FROM Customer c ";

        public override IEnumerable<ICustomer> GetAll()
        {
            using (var conn = OpenDbConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = SELECT_SQL;
                    var reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        yield return Map(reader);
                    }
                }
            }
        }

        public override ICustomer GetById(int id)
        {
            using (var conn = OpenDbConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = SELECT_SQL + "WHERE c.Id = @id;";
                    cmd.AddParameter("@id", id);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return Map(reader);
                    }
                    return null;
                }
            }
        }

        public ICustomer GetByProjectId(int id)
        {
            using (var conn = OpenDbConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = SELECT_SQL + "JOIN Project p ON p.CustomerId = c.Id WHERE p.Id = @id;";
                    cmd.AddParameter("@id", id);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return Map(reader);
                    }
                    return null;
                }
            }
        }

        private ICustomer Map(IDataReader reader)
        {
            return new Customer(OpenDbConnection)
            {
                Id = Convert.ToInt32(reader[ID]),
                Name = Convert.ToString(reader[NAME]),
                Address = Convert.ToString(reader[ADDRESS]),
                Address2 = Convert.ToString(reader[ADDRESS2]),
                Zip = Convert.ToString(reader[ZIP]),
                City = Convert.ToString(reader[CITY]),
                Country = Convert.ToString(reader[COUNTRY]),
                Email = Convert.ToString(reader[EMAIL]),
                Phone = Convert.ToString(reader[PHONE])
            };
        }
    }
}
