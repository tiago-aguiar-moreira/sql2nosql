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
    public class CredentialTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly string _host;
        private readonly int _port;
        private readonly string _user;
        private readonly string _password;
        private readonly string _databaseName;
        private readonly DatabaseSQL _databaseSQL;
        private readonly Faker _faker;

        public CredentialTest(ITestOutputHelper output)
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
            var expectedCredential = new
            {
                Host = _host,
                User = _user,
                Password = _password,
                DatabaseName = _databaseName,
                DatabaseSQL = _databaseSQL
            };

            var credential = new CredentialSQL(
                expectedCredential.Host,
                expectedCredential.User,
                expectedCredential.Password,
                expectedCredential.DatabaseName,
                expectedCredential.DatabaseSQL);

            expectedCredential.ToExpectedObject().ShouldMatch(credential);
        }

        [Fact(DisplayName = "Should create connection string to SQL Server")]
        public void ShouldCreateConnectionStringToSqlServer()
        {
            var expectedConnectionString = $"Data Source={_host};Initial Catalog={_databaseName};User ID={_user};Password={_password}";

            var connectionString = new CredentialSQL(_host, _user, _password, _databaseName, _databaseSQL).GetConnectionString();

            Assert.Equal(expectedConnectionString, connectionString);
        }

        [Fact(DisplayName = "Should create connection string, not sharded cluster, to MongoDB")]
        public void ShouldCreateConnectionStringNotShardedClusterToMongoDB()
        {
            var expectedConnectionString = $"mongodb://{_user}:{_password}@{_host}:{_port}";

            var listConnectionString = new List<string>
            {
                _host
            };

            var connectionString = new CredentialMongoDB(listConnectionString, _port, _user, _password, _databaseName).GetConnectionString();

            Assert.Equal(expectedConnectionString, connectionString);
        }

        //[Fact(DisplayName = "Should create connection string, sharded cluster, to MongoDB")]
        //public void ShouldCreateConnectionStringShardedClusterToMongoDB()
        //{
        //    var expectedConnectionString = $"mongodb://{_user}:{_password}@{_host}:{_port}";

        //    var listConnectionString = new List<string>
        //    {
        //        _host
        //    };

        //    var connectionString = new CredentialMongoDB(listConnectionString, _port, _user, _password, _databaseName).GetConnectionString();

        //    Assert.Equal(expectedConnectionString, connectionString);
        //}
    }
}