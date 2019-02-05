using CentiSoft.TimeReg.Repository.Interface;
using System;
using System.Data.SqlClient;

namespace CentiSoft.TimeReg.Repository.Model
{
    class Task : ITask
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public float Duration { get; set; }
        public IProject Project { get; set; }
        public IDeveloper Developer { get; set; }

        public bool Delete(string connStr)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (var cmd = new SqlCommand("DELETE FROM Task WHERE Id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Id);
                    var rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected == 1;
                }
            }
        }

        public bool Update(string connStr)
        {
            if (Id == 0)
            {
                // insert new row
                var insertSql = "INSERT INTO Task (Name, Duration, Description, Created) " +
                    "VALUES (@name, @duration, @description, @created); SELECT SCOPE_IDENTITY()";
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", Name);
                        cmd.Parameters.AddWithValue("@duration", Duration);
                        cmd.Parameters.AddWithValue("@description", Description);
                        cmd.Parameters.AddWithValue("@created", DateTime.Now);
                        
                        Id = Convert.ToInt32(cmd.ExecuteScalar());

                        return Id != 0;
                    }
                }
            }
            else
            {
                // update existing
                var updateSql = "UPDATE Task SET Name = @name, Duration = @duration, Description = @description" +
                    "WHERE Id = @id";
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(updateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", Id);
                        cmd.Parameters.AddWithValue("@name", Name);
                        cmd.Parameters.AddWithValue("@duration", Duration);
                        cmd.Parameters.AddWithValue("@description", Description);
                        cmd.Parameters.AddWithValue("@created", Created);

                        return cmd.ExecuteNonQuery() == 1;
                    }
                }
            }
        }
    }
}
