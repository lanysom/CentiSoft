using CentiSoft.TimeRegistration.DataAccessLayer.Helpers;
using CentiSoft.TimeRegistration.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Factories
{
    internal sealed class CustomerFactory : EntityFactory<ICustomer>
    {
        public CustomerFactory(Func<IDbConnection> dbConnectionFactory)
            : base(dbConnectionFactory, "SELECT Customer.Id, Customer.Name, Customer.Address, Customer.Address2, Customer.Zip, Customer.City, Customer.Country, Customer.Email, Customer.Phone, Customer.ClientId FROM Customer ")
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


        internal IEnumerable<ICustomer> GetByClient(int id)
        {
            using (var conn = OpenDbConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"{SelectSql} WHERE Customer.ClientId = @id;";
                    cmd.AddParameter("@id", id);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        yield return Map(reader);
                    }
                }
            }
        }

        internal ICustomer GetByProject(int id)
        {
            using (var conn = OpenDbConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"{SelectSql} JOIN Project ON Project.CustomerId = Customer.Id WHERE Project.Id = @id;";
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

        private ICustomer Map(IDataReader reader, bool includeProject = true, bool includeClient = true)
        {
            var customer = new Customer(OpenDbConnection)
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

            if (includeProject)
            {
                var projectFactory = EntityFactory.Use<IProject>(OpenDbConnection) as ProjectFactory;
                customer.Projects = projectFactory.GetByCustomer(customer.Id).ToList();
            }

            if (includeClient)
            {
                var clientFactory = EntityFactory.Use<IClient>(OpenDbConnection) as ClientFactory;
                customer.Client = clientFactory.GetByCustomer(customer.Id);
            }

            return customer;
        }

        protected override ICustomer Map(IDataReader reader)
        {
            return Map(reader);
        }
    }
}
