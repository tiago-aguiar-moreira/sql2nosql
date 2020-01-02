using SQL2NoSQL.Core.Model;
using System;
using System.Data.SqlClient;

namespace SQL2NoSQL.Core
{
    public class SQL : ISQL
    {
        public SqlDataReader ListDatabase()
        {
            throw new NotImplementedException();
        }

        public SqlDataReader ListTables()
        {
            throw new NotImplementedException();
        }

        public bool TestConnection()
        {
            throw new NotImplementedException();
        }

        public bool TestConnection(Credential credential)
        {
            throw new NotImplementedException();
        }
    }
}
