using System.Data.SqlClient;

namespace CentiSoft.TimeRegistration.DataAccessLayer
{
    public interface IEntity
    {
        int Id { get; }
        void Update();
        void Delete();
    }
}
