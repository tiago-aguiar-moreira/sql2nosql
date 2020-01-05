using System.Data.SqlClient;

namespace SQL2NoSQL.Core.Interface
{
    public interface ISQL
    {
        SqlDataReader ListDatabase();

        SqlDataReader ListTable();

        bool TestConnection();
    }
}