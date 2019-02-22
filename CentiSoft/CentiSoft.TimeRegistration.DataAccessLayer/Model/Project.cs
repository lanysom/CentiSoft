using CentiSoft.TimeReg.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CentiSoft.TimeReg.Repository.Model
{
    class Project : IProject
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public ICustomer Customer { get; set; }
        public IList<ITask> Tasks { get; set; }

        public bool Delete(string connStr)
        {
            throw new NotImplementedException();
        }

        public bool Update(string connStr)
        {
            throw new NotImplementedException();
        }
    }
}
