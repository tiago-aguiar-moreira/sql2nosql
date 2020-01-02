using SQL2NoSQL.Core.Model;
using System;
using System.Data.SqlClient;

namespace SQL2NoSQL.Core
{
    public class SqlServer : ISQL
    {
        private SqlConnection _connection;
        private Credential _credential;

        public SqlServer(Credential credential)
        {
            _credential = credential;
            // 
            //_connection = new SqlConnection()
        }

        public SqlDataReader ListDatabase()
        {
            throw new NotImplementedException();
        }

        public SqlDataReader ListTables()
        {
            throw new NotImplementedException();
        }

        public bool TestConnection(Credential credential)
        {
            throw new NotImplementedException();
        }
    }
}
