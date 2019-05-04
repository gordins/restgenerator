using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using RestGenerator.Entity;
using RestGenerator.Infrastructure.Configurations;
using RestGenerator.Infrastructure.DataAccess;

namespace RestGenerator.DataAccess.Implementation
{
    internal class ApiRepository : IApiRepository
    {
        private readonly string databaseConnectionString;

        public ApiRepository(IConfigurations configurations)
        {
            this.databaseConnectionString = configurations.DatabaseConnectionString;
        }

        public List<Api> GetAll()
        {
            const string Sql = @"
SELECT [Id], [Name], [EncryptionKey], [DecryptionKey], [IsActive]
FROM [restGenerator].[Api]";

            return this.databaseConnectionString.Query(db => db.Query<Api>(Sql)).ToList();
        }

        public Api GetById(Guid id)
        {
            const string Sql = @"
SELECT [Id], [Name], [EncryptionKey], [DecryptionKey], [IsActive]
FROM [restGenerator].[Api]
WHERE [Id] = @Id";

            return this.databaseConnectionString.Query(db => db.Query<Api>(Sql, new { Id = id }).SingleOrDefault());
        }

        public Api Save(Api api)
        {
            const string Sql = @"
INSERT INTO [restGenerator].[Api]
  ([Id], [Name], [EncryptionKey], [DecryptionKey], [IsActive])
VALUES
  (@Id, @Name, @EncryptionKey, @DecryptionKey, @IsActive)

SELECT [Id], [Name], [EncryptionKey], [DecryptionKey], [IsActive]
FROM [restGenerator].[Api]
WHERE [Id] = @Id";

            if (api.Id == Guid.Empty)
            {
                api.Id = Guid.NewGuid();
            }

            return this.databaseConnectionString.Query(db => db.Query<Api>(Sql, api).SingleOrDefault());
        }

        public Api Update(Guid id, Api api)
        {
            const string Sql = @"
UPDATE [restGenerator].[Api]
SET [Name] = @Name,
    [EncryptionKey] = @EncryptionKey,
    [DecryptionKey] = @DecryptionKey,
    [IsActive] = @IsActive
WHERE [Id] = @Id

SELECT [Id], [Name], [EncryptionKey], [DecryptionKey], [IsActive]
FROM [restGenerator].[Api]
WHERE [Id] = @Id";

            api.Id = id;

            return this.databaseConnectionString.Query(db => db.Query<Api>(Sql, api).SingleOrDefault());
        }

        public void DeleteAll()
        {
            const string Sql = @"
DELETE [restGenerator].[Field]
DELETE [restGenerator].[Resource]
DELETE [restGenerator].[Api]";

            this.databaseConnectionString.Execute(db => db.Execute(Sql));
        }

        public void DeleteById(Guid id)
        {
            const string Sql = @"
DELETE [restGenerator].[Field] WHERE [ResourceId] IN (SELECT [Id] FROM [restGenerator].[Resource] WHERE [ApiId] = @Id)
DELETE [restGenerator].[Resource] WHERE [ApiId] = @Id
DELETE [restGenerator].[Api] WHERE [Id] = @Id";

            this.databaseConnectionString.Execute(db => db.Execute(Sql, new { Id = id }));
        }
    }
}
