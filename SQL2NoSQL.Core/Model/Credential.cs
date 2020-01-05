using SQL2NoSQL.Core.Enum;
using SQL2NoSQL.Core.Interface;
using System;

namespace SQL2NoSQL.Core.Model
{
    public class Credential : ICredential
    {
        private const string _connectionString = "Data Source={0};Initial Catalog={1};User ID={2};Password={3}";
        public string Host { get; }
        public string User { get; }
        public string Password { get; }
        public string DatabaseName { get; }
        public DatabaseSQL DatabaseSQL { get; }

        public Credential(string host, string user, string password, string databasename, DatabaseSQL databaseSQL)
        {
            Host = host;
            User = user;
            Password = password;
            DatabaseName = databasename;
            DatabaseSQL = databaseSQL;
        }

        public string GetConnectionString() => DatabaseSQL switch
        {
            DatabaseSQL.SqlServer => string.Format(_connectionString, Host, DatabaseName, User, Password),
            _ => throw new ArgumentException("Banco de dados não suportado")
        };
    }
}
