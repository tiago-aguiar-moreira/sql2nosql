using SQL2NoSQL.Core.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SQL2NoSQL.Core.Model
{
    public class CredentialMongoDB : ICredential
    {
        public IList<string> Host { get; private set; }
        public int Port { get; private set; }
        public string User { get; private set; }
        public string Password { get; private set; }
        public string DatabaseName { get; private set; }

        public CredentialMongoDB(IList<string> host, int port, string user, string password, string databasename)
        {
            Host = host;
            User = user;
            Password = password;
            DatabaseName = databasename;
            Port = port;
        }

        public string GetConnectionString()
        {
            var host = string.Join(',', Host.Select(s => string.Concat(s, ":", Port)));

            return $"mongodb://{User}:{Password}@{host}";
        }
    }
}