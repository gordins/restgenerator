using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using RestGenerator.Entity;
using RestGenerator.Infrastructure.Configurations;
using RestGenerator.Infrastructure.DataAccess;

namespace RestGenerator.DataAccess.Implementation
{
    internal class ResourceRepository : IResourceRepository
    {
        private readonly string databaseConnectionString;

        public ResourceRepository(IConfigurations configurations)
        {
            this.databaseConnectionString = configurations.DatabaseConnectionString;
        }

        public List<Resource> GetAll(Guid apiId)
        {
            const string Sql = @"
SELECT r.[Id], r.[ApiId], r.[Name], f.[Id], f.[ResourceId], f.[Name], f.[Type], f.[IsEncrypted], f.[IsRequired], f.[IsUnique]
FROM [restGenerator].[Resource] r
JOIN [restGenerator].[Field] f ON r.[Id] = f.[ResourceId]
WHERE r.[ApiId] = @ApiId";

            return this.databaseConnectionString.Query(db =>
            {
                var resources = new Dictionary<Guid, Resource>();

                db.Query(Sql, (Func<Resource, Field, Resource>) ((r, f) =>
                {
                    if (!resources.TryGetValue(r.Id, out var resource))
                    {
                        resources.Add(r.Id, resource = r);
                    }
                    if (resource.Fields == null)
                    {
                        resource.Fields = new List<Field>();
                    }
                    resource.Fields.Add(f);
                    return new Resource();
                }), new { ApiId = apiId });
                return resources.Values;
            }).ToList();
        }

        public Resource GetById(Guid id)
        {
            const string Sql = @"
SELECT r.[Id], r.[ApiId], r.[Name], f.[Id], f.[ResourceId], f.[Name], f.[Type], f.[IsEncrypted], f.[IsRequired], f.[IsUnique]
FROM [restGenerator].[Resource] r
JOIN [restGenerator].[Field] f ON r.[Id] = f.[ResourceId]
WHERE r.[Id] = @Id";
            return this.databaseConnectionString.Query(db =>
            {
                Resource resource = null;

                db.Query(Sql, (Func<Resource, Field, Resource>) ((r, f) =>
                {
                    if (resource == null)
                    {
                        resource = r;
                    }
                    if (resource.Fields == null)
                    {
                        resource.Fields = new List<Field>();
                    }
                    resource.Fields.Add(f);
                    return new Resource();
                }), new { Id = id });
                return resource;
            });
        }

        public Resource Save(Resource resource)
        {
            const string Sql = @"
INSERT INTO [restGenerator].[Resource]
  ([Id], [ApiId], [Name])
VALUES
  (@Id, @ApiId, @Name)

SELECT [Id], [ApiId], [Name]
FROM [restGenerator].[Resource]
WHERE [Id] = @Id";

            if (resource.Id == Guid.Empty)
            {
                resource.Id = Guid.NewGuid();
            }

            return this.databaseConnectionString.Query(db => db.Query<Resource>(Sql, resource).SingleOrDefault());
        }

        public Resource Update(Guid id, Resource resource)
        {
            const string Sql = @"
UPDATE [restGenerator].[Resource]
SET [ApiId] = @ApiId,
    [Name] = @Name
WHERE [Id] = @Id

SELECT [Id], [ApiId], [Name]
FROM [restGenerator].[Resource]
WHERE [Id] = @Id";

            resource.Id = id;

            return this.databaseConnectionString.Query(db => db.Query<Resource>(Sql, resource).SingleOrDefault());
        }

        public void DeleteAll(Guid apiId)
        {
            const string Sql = @"
DELETE [restGenerator].[Field] WHERE [ResourceId] IN (SELECT [Id] FROM [restGenerator].[Resource] WHERE [ApiId] = @ApiId)
DELETE [restGenerator].[Resource] WHERE [ApiId] = @ApiId";

            this.databaseConnectionString.Execute(db => db.Execute(Sql, new { ApiId = apiId }));
        }

        public void DeleteById(Guid id)
        {
            const string Sql = @"
DELETE [restGenerator].[Field] WHERE [ResourceId] = @Id
DELETE [restGenerator].[Resource] WHERE [Id] = @Id";

            this.databaseConnectionString.Execute(db => db.Execute(Sql, new { Id = id }));
        }
    }
}
