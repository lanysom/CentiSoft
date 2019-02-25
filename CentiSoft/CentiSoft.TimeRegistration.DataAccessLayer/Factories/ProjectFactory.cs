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
        //private TaskFactory _taskFactory;
        //private CustomerFactory _customerFactory;

        public ProjectFactory(Func<IDbConnection> dbConnectionFactory) 
            : base(dbConnectionFactory, "SELECT Project.Id, Project.Name, Project.DueDate, Project.CustomerId FROM Project ")
        {
        }

        public override IProject Create()
        {
            return new Project(OpenDbConnection)
            {
                Tasks = new List<ITask>()
            };
        }

        private const int PROJECT_ID = 0;
        private const int PROJECT_NAME = 1;
        private const int PROJECT_DUEDATE = 2;
        private const int CUSTOMER_ID = 3;

        internal IProject GetByTask(int id)
        {
            using (var conn = OpenDbConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"{SelectSql} JOIN Task ON Task.ProjectId = Project.Id WHERE Task.Id = @id;";
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

        internal IEnumerable<IProject> GetByCustomer(int id)
        {
            using (var conn = OpenDbConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"{SelectSql} WHERE Project.CustomerId = @id;";
                    cmd.AddParameter("@id", id);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        yield return Map(reader, includeCustomer: false);
                    }
                }
            }
        }

        private IProject Map(IDataReader reader, bool includeTasks = true, bool includeCustomer = true)
        {
            var project = new Project(OpenDbConnection)
            {
                Id = Convert.ToInt32(reader[PROJECT_ID]),
                Name = Convert.ToString(reader[PROJECT_NAME]),
                DueDate = Convert.ToDateTime(reader[PROJECT_DUEDATE])
            };

            if (includeTasks)
            {
                var taskFactory = EntityFactory.Use<ITask>(OpenDbConnection) as TaskFactory;
                project.Tasks = taskFactory.GetByProject(project.Id).ToList();
            }

            if (includeCustomer)
            {
                var customerFactory = EntityFactory.Use<ICustomer>(OpenDbConnection) as CustomerFactory;
                project.Customer = customerFactory.GetByProject(project.Id);
            }

            return project;
        }

        protected override IProject Map(IDataReader reader)
        {
            return Map(reader);
        }
    }
}
