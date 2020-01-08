using Bogus;
using ExpectedObjects;
using SQL2NoSQL.Core.Enum;
using SQL2NoSQL.Core.Model;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace SQL2NoSQL.Test
{
    public class CredentialMongoDBTeste : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly string _host;
        private readonly int _port;
        private readonly string _user;
        private readonly string _password;
        private readonly string _databaseName;
        private readonly DatabaseSQL _databaseSQL;
        private readonly Faker _faker;

        public CredentialMongoDBTeste(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Test class Credential started");

            _faker = new Faker();
            
            _host = _faker.Internet.Ip();
            _port = _faker.Random.Number(65535);
            _user = _faker.Internet.UserName();
            _password = _faker.Internet.Password();
            _databaseName = "marketplace";
            _databaseSQL = DatabaseSQL.SqlServer;
        }

        public void Dispose()
        {
            _output.WriteLine("Test class Credential finished");
        }

        [Fact(DisplayName = "Should create credential")]
        public void ShouldCreateCredential()
        {
            var listConnectionString = new List<string>
            {
                "mongos0.example.com"
            };

            var expectedCredential = new
            {
                Host = listConnectionString,
                Port = _port,
                User = _user,
                Password = _password,
                DatabaseName = _databaseName
            };

            var credential = new CredentialMongoDB(
                expectedCredential.Host,
                expectedCredential.Port,
                expectedCredential.User,
                expectedCredential.Password,
                expectedCredential.DatabaseName);

            expectedCredential.ToExpectedObject().ShouldMatch(credential);
        }

        [Fact(DisplayName = "Should create connection string, not sharded cluster, to MongoDB")]
        public void ShouldCreateConnectionStringNotShardedClusterToMongoDB()
        {
            var host = "mongos0.example.com";

            var expectedConnectionString = $"mongodb://{_user}:{_password}@{host}:{_port}";

            var listConnectionString = new List<string>
            {
                host
            };

            var connectionString = new CredentialMongoDB(listConnectionString, _port, _user, _password, _databaseName).GetConnectionString();

            Assert.Equal(expectedConnectionString, connectionString);
        }

        [Fact(DisplayName = "Should create connection string, sharded cluster, to MongoDB")]
        public void ShouldCreateConnectionStringShardedClusterToMongoDB()
        {
            var conn1 = "mongos0.example.com";
            var conn2 = "mongos1.example.com";
            var conn3 = "mongos2.example.com";
            var expectedConnectionString = $"mongodb://{_user}:{_password}@{conn1}:{_port},{conn2}:{_port},{conn3}:{_port}";

            var listConnectionString = new List<string>
            {
                conn1, conn2, conn3
            };

            var connectionString = new CredentialMongoDB(listConnectionString, _port, _user, _password, _databaseName).GetConnectionString();

            Assert.Equal(expectedConnectionString, connectionString);
        }
    }
}