using CentiSoft.TimeRegistration.DataAccessLayer.Helpers;
using CentiSoft.TimeRegistration.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Factories
{
    internal sealed class DeveloperFactory : EntityFactory<IDeveloper>
    {
        public DeveloperFactory(Func<IDbConnection> dbConnectionFactory)
            : base(dbConnectionFactory, "SELECT Developer.Id, Developer.Name, Developer.Email FROM Developer ")
        {
        }

        public override IDeveloper Create()
        {
            return new Developer(OpenDbConnection)
            {
                Tasks = new List<ITask>()
            };
        }

        public const int ID = 0;
        public const int NAME = 1;
        public const int EMAIL = 2;

        internal IDeveloper GetByTask(int id)
        {
            using (var conn = OpenDbConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"{SelectSql} JOIN Task ON Task.DeveloperId = Developer.Id WHERE Task.Id = @id;";
                    cmd.AddParameter("@id", id);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return Map(reader, includeTasks: false);
                    }
                    return null;
                }
            }
        }

        private IDeveloper Map(IDataReader reader, bool includeTasks = true)
        {
            var developer = new Developer(OpenDbConnection)
            {
                Id = Convert.ToInt32(reader[ID]),
                Name = Convert.ToString(reader[NAME]),
                Email = Convert.ToString(reader[EMAIL])
            };

            if (includeTasks)
            {
                var taskFactory = EntityFactory.Use<ITask>(OpenDbConnection) as TaskFactory;
                developer.Tasks = taskFactory.GetByDeveloper(developer.Id).ToList();
            }
            return developer;
        }

        protected override IDeveloper Map(IDataReader reader)
        {
            return Map(reader);
        }
    }
}
