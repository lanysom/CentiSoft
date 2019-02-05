using CentiSoft.TimeReg.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CentiSoft.TimeReg.Repository.Model
{
    class Developer : IDeveloper
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
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
