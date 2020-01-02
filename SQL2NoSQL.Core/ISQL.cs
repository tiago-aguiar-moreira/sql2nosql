using SQL2NoSQL.Core.Model;
using System.Data.SqlClient;

namespace SQL2NoSQL.Core
{
    public interface ISQL
    {
        SqlDataReader ListDatabase();

        SqlDataReader ListTables();

        bool TestConnection(Credential credential);
    }
}