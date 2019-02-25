using CentiSoft.TimeRegistration.DataAccessLayer.Helpers;
using CentiSoft.TimeRegistration.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Factories
{
    internal sealed class TaskFactory : EntityFactory<ITask>
    {
        public TaskFactory(Func<IDbConnection> dbConnectionFactory)
            : base(dbConnectionFactory, "SELECT Task.Id, Task.Name, Task.Description, Task.Created, Task.Duration, Task.ProjectId, Task.DeveloperId FROM Task ")
        {
        }

        public override ITask Create()
        {
            return new Task(OpenDbConnection);
        }

        public const int TASK_ID = 0;
        public const int TASK_NAME = 1;
        public const int TASK_DESCRIPTION = 2;
        public const int TASK_CREATED = 3;
        public const int TASK_DURATION = 4;
        public const int TASK_PROJECT_ID = 5;
        public const int TASK_DEVELOPER_ID = 6;

        internal IEnumerable<ITask> GetByProject(int id)
        {
            using (var conn = OpenDbConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"{SelectSql} WHERE Task.ProjectId = @project_id;";
                    var projectIdParam = cmd.CreateParameter();
                    projectIdParam.ParameterName = "@project_id";
                    projectIdParam.Value = id;
                    cmd.Parameters.Add(projectIdParam);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        yield return Map(reader, includeProject: false);
                    }
                }
            }
        }

        internal IEnumerable<ITask> GetByDeveloper(int id)
        {
            using (var conn = OpenDbConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"{SelectSql} WHERE Task.DeveloperId = @developer_id;";
                    cmd.AddParameter("@developer_id", id);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        yield return Map(reader, includeDeveloper: false);
                    }
                }
            }
        }

        private ITask Map(IDataReader reader, bool includeProject = true, bool includeDeveloper = true)
        {
            var task = new Task(OpenDbConnection)
            {
                Id = Convert.ToInt32(reader[TASK_ID]),
                Name = Convert.ToString(reader[TASK_NAME]),
                Description = Convert.ToString(reader[TASK_DESCRIPTION]),
                Duration = Convert.ToSingle(reader[TASK_DURATION]),
                Created = Convert.ToDateTime(reader[TASK_CREATED])
            };

            if (includeProject)
            {
                var projectFactory = EntityFactory.Use<IProject>(OpenDbConnection) as ProjectFactory;
                task.Project = projectFactory.GetByTask(task.Id);
            }

            if (includeDeveloper)
            {
                var developerFactory = EntityFactory.Use<IDeveloper>(OpenDbConnection) as DeveloperFactory;
                task.Developer = developerFactory.GetByTask(task.Id);
            }

            return task;
        }

        protected override ITask Map(IDataReader reader)
        {
            return Map(reader);
        }
    }
}
