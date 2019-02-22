using System.Data.SqlClient;

namespace CentiSoft.TimeReg.Repository.Interface
{
    public interface IEntity
    {
        int Id { get; }
        bool Update(string connStr);
        bool Delete(string connStr);
    }
}
