using SQL2NoSQL.Core.Interface;
using SQL2NoSQL.Core.Model;
using System;
using System.Data.SqlClient;

namespace SQL2NoSQL.Core
{
    public class SqlServer : ISQL
    {
        private SqlConnection _connection;

        public SqlServer(Credential credential)
        {
            _connection = new SqlConnection(credential.GetConnectionString());
        }

        public SqlDataReader ListDatabase()
        {
            throw new NotImplementedException();
        }

        public SqlDataReader ListTable()
        {
            throw new NotImplementedException();
        }

        public bool TestConnection()
        {
            throw new NotImplementedException();
        }
    }
}
