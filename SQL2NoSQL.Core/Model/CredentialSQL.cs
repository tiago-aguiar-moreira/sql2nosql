using SQL2NoSQL.Core.Enum;
using SQL2NoSQL.Core.Interface;
using System;

namespace SQL2NoSQL.Core.Model
{
    public class CredentialSQL : ICredential
    {
        public string Host { get; private set; }
        public string User { get; private set; }
        public string Password { get; private set; }
        public string DatabaseName { get; private set; }
        public DatabaseSQL DatabaseSQL { get; private set; }

        public CredentialSQL(string host, string user, string password, string databasename, DatabaseSQL databaseSQL)
        {
            Host = host;
            User = user;
            Password = password;
            DatabaseName = databasename;
            DatabaseSQL = databaseSQL;
        }

        public string GetConnectionString() => DatabaseSQL switch
        {
            DatabaseSQL.SqlServer => $"Data Source={Host};Initial Catalog={DatabaseName};User ID={User};Password={Password}",
            _ => throw new ArgumentException("Database is not suported")
        };
    }
}
