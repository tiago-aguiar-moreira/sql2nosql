namespace SQL2NoSQL.Core.Model
{
    public class Credential
    {
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }

        public Credential(string host, string user, string password, string databasename)
        {
            Host = host;
            User = user;
            Password = password;
            DatabaseName = databasename;
    }
    }
}
