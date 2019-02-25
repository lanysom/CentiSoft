using CentiSoft.TimeRegistration.DataAccessLayer.Helpers;
using CentiSoft.TimeRegistration.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Factories
{
    internal sealed class ClientFactory : EntityFactory<IClient>
    {
        public ClientFactory(Func<IDbConnection> dbConnectionFactory) 
            : base(dbConnectionFactory, "SELECT Client.Id, Client.Name, Client.Token FROM Client ")
        {
        }

        public override IClient Create()
        {
            return new Client(OpenDbConnection)
            {
                Customers = new List<ICustomer>()
            };
        }

        public const int ID = 0;
        public const int NAME = 1;
        public const int TOKEN = 2;
                
        internal IClient GetByCustomer(int id)
        {
            using (var conn = OpenDbConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"{SelectSql} JOIN Customer ON Customer.ClientId = Client.Id WHERE Customer.Id = @id;";
                    cmd.AddParameter("@id", id);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return Map(reader, includeCustomer: false);
                    }
                    return null;
                }
            }
        }

        private IClient Map(IDataReader reader, bool includeCustomer = true)
        {
            var client = new Client(OpenDbConnection)
            {
                Id = Convert.ToInt32(reader[ID]),
                Name = Convert.ToString(reader[NAME]),
                Token = Convert.ToString(reader[TOKEN])
            };
            

            if (includeCustomer)
            {
                var customerFactory = EntityFactory.Use<ICustomer>(OpenDbConnection) as CustomerFactory;
                client.Customers = customerFactory.GetByClient(client.Id).ToList();
            }

            return client;
        }

        protected override IClient Map(IDataReader reader)
        {
            return Map(reader);
        }
    }
}
