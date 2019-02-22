using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CentiSoft.TimeRegistration.DataAccessLayer.Helpers
{
    static class DbExtensions
    {
        public static void AddParameter(this IDbCommand cmd, string name, object value)
        {
            var param = cmd.CreateParameter();
            param.ParameterName = name;
            param.Value = value;
            cmd.Parameters.Add(param);
        }
    }
}
