using ExpectedObjects;
using SQL2NoSQL.Core.Enum;
using SQL2NoSQL.Core.Model;
using System;
using Xunit;

namespace SQL2NoSQL.Test
{
    public class CredentialTest
    {
        [Fact(DisplayName = "Should create credential")]
        public void ShouldCreateCredential()
        {
            var random = new Random();
            var host = $"{random.Next(255)}.{random.Next(255)}.{random.Next(255)}.{random.Next(255)}";

            var expectedCredential = new
            {
                Host = host,
                User = "tiago.aguiar",
                Password = "wrW6VlA9Fml!Yyr$6znlX&&l4",
                DatabaseName = "marketplace",
                DatabaseSQL = DatabaseSQL.SqlServer
            };

            var credential = new Credential(
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
            var random = new Random();
            var host = $"{random.Next(255)}.{random.Next(255)}.{random.Next(255)}.{random.Next(255)}";
            var user = "tiago.aguiar";
            var password = "wrW6VlA9Fml!Yyr$6znlX&&l4";
            var databaseName = "marketplace";
            var databaseSQL = DatabaseSQL.SqlServer;

            var expectedConnectionString = $"Data Source={host};Initial Catalog={databaseName};User ID={user};Password={password}";

            var credential = new Credential(host, user, password, databaseName, databaseSQL);

            var connectionString = credential.GetConnectionString();

            Assert.Equal(expectedConnectionString, connectionString);
        }
    }
}