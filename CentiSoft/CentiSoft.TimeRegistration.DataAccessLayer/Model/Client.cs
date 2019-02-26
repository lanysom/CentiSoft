using CentiSoft.TimeRegistration.DataAccessLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Data;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Model
{
    internal class Client : EntityBase, IClient
    {
        public Client(Func<IDbConnection> connectionFactory) : base(connectionFactory)
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public IList<ICustomer> Customers { get; set; }

        public void Delete()
        {
            using (var conn = OpenDbConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Client WHERE Id = @id;";
                    cmd.AddParameter("@id", Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update()
        {
            using (var conn = OpenDbConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    if (Id == 0)
                    {
                        // insert
                        cmd.CommandText = "INSERT INTO Client (Name) VALUES(@name); SELECT SCOPE_IDENTITY();";
                        cmd.AddParameter("@name", Name);
                        Id = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    else
                    {
                        // update
                        cmd.CommandText = "UPDATE Client SET Name = @name WHERE Id = @id;";
                        cmd.AddParameter("@name", Name);
                        cmd.AddParameter("@id", Id);
                        cmd.ExecuteNonQuery();
                    }

                }
            }

        }
    }
}
