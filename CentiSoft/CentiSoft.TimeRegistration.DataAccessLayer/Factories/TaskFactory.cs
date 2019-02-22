﻿using CentiSoft.TimeRegistration.DataAccessLayer.Helpers;
using CentiSoft.TimeRegistration.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Factories
{
    internal sealed class TaskFactory : EntityFactory<ITask>
    {
        private readonly ProjectFactory _projectFactory;
        private readonly DeveloperFactory _developerFactory;

        public TaskFactory(Func<IDbConnection> dbConnectionFactory) : base(dbConnectionFactory)
        {
            _projectFactory= EntityFactory<IProject>.Use(dbConnectionFactory) as ProjectFactory;
            _developerFactory = EntityFactory<IDeveloper>.Use(dbConnectionFactory) as DeveloperFactory;
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

        private const string SELECT_SQL = "SELECT t.Id, t.Name, t.Description, t.Created, t.Duration, t.ProjectId, t.DeveloperId " +
                                          "FROM Task t ";

        public override IEnumerable<ITask> GetAll()
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

        public override ITask GetById(int id)
        {
            using (var conn = OpenDbConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = SELECT_SQL + "WHERE Id = @id;";
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return Map(reader);
                    }
                    return null;
                }
            }
        }

        internal IEnumerable<ITask> GetByProject(int id)
        {
            using (var conn = OpenDbConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = SELECT_SQL + "WHERE ProjectId = @project_id;";
                    var projectIdParam = cmd.CreateParameter();
                    projectIdParam.ParameterName = "@project_id";
                    projectIdParam.Value = id;
                    cmd.Parameters.Add(projectIdParam);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        yield return Map(reader);
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
                    cmd.CommandText = SELECT_SQL + "WHERE DeveloperId = @developer_id;";
                    cmd.AddParameter("@developer_id", id);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        yield return Map(reader);
                    }
                }
            }
        }

        private ITask Map(IDataReader reader, bool includeDeveloper = true, bool includeProject = true)
        {
            var task = new Task(OpenDbConnection)
            {
                Id = Convert.ToInt32(reader[TASK_ID]),
                Name = Convert.ToString(reader[TASK_NAME]),
                Description = Convert.ToString(reader[TASK_DESCRIPTION]),
                Duration = Convert.ToSingle(reader[TASK_DURATION]),
                Created = Convert.ToDateTime(reader[TASK_CREATED])
            };

            if (includeDeveloper)
            {
                task.Developer = _developerFactory.GetByTaskId(task.Id);
            }

            if (includeProject)
            {
                task.Project = _projectFactory.GetByTaskId(task.Id);
            }


            return task;
        }
    }
}
