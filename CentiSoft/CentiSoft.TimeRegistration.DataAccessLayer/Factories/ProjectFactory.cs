using CentiSoft.TimeRegistration.DataAccessLayer.Helpers;
using CentiSoft.TimeRegistration.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Factories
{
    internal sealed class ProjectFactory : EntityFactory<IProject>
    {
        private TaskFactory _taskFactory;
        private CustomerFactory _customerFactory;

        public ProjectFactory(Func<IDbConnection> dbConnectionFactory) : base(dbConnectionFactory)
        {
            _taskFactory = EntityFactory<ITask>.Use(dbConnectionFactory) as TaskFactory;
            _customerFactory = EntityFactory<ICustomer>.Use(dbConnectionFactory) as CustomerFactory;
        }

        public override IProject Create()
        {
            return new Project(OpenDbConnection)
            {
                Tasks = new List<ITask>()
            };
        }

        private const string SELECT_SQL = "SELECT p.Id, p.Name, p.DueDate, p.CustomerId " +
                                          "FROM Project p ";

        private const int PROJECT_ID = 0;
        private const int PROJECT_NAME = 1;
        private const int PROJECT_DUEDATE = 2;
        private const int CUSTOMER_ID = 3;

        public override IEnumerable<IProject> GetAll()
        {
            using (var conn = OpenDbConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = SELECT_SQL;

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        yield return Map(reader);
                    }
                }
            }
        }

        public override IProject GetById(int id)
        {
            using (var conn = OpenDbConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText =  $"{SELECT_SQL} WHERE p.Id = @id;";

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return Map(reader);
                    }
                    return null;
                }
            }
        }

        internal IProject GetByTaskId(int id)
        {
            using (var conn = OpenDbConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"{SELECT_SQL} JOIN Task t ON t.ProjectId = p.Id WHERE t.Id = @id;";
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

        private IProject Map(IDataReader reader)
        {

            var project = new Project(OpenDbConnection)
            {
                Id = Convert.ToInt32(reader[PROJECT_ID]), 
                Name = Convert.ToString(reader[PROJECT_NAME]),
                DueDate = Convert.ToDateTime(reader[PROJECT_DUEDATE])                
            };

            project.Tasks = _taskFactory.GetByProject(project.Id).ToList();

            if (reader[CUSTOMER_ID] != DBNull.Value)
            {
                project.Customer = _customerFactory.GetByProjectId(Convert.ToInt32(reader[PROJECT_ID]));
            };

            return project;
        }

    }
}
