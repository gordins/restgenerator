using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using RestGenerator.Entity;
using RestGenerator.Infrastructure.Configurations;
using RestGenerator.Infrastructure.DataAccess;

namespace RestGenerator.DataAccess.Implementation
{
    internal class FieldRepository : IFieldRepository
    {
        private readonly string databaseConnectionString;

        public FieldRepository(IConfigurations configurations)
        {
            this.databaseConnectionString = configurations.DatabaseConnectionString;
        }

        public List<Field> GetAll(Guid resourceId)
        {
            const string Sql = @"
SELECT [Id], [ResourceId], [Name], [Type], [IsRequired], [IsUnique], [IsEncrypted]
FROM [restGenerator].[Field]
WHERE [ResourceId] = @ResourceId";

            return this.databaseConnectionString.Query(db => db.Query<Field>(Sql, new { ResourceId = resourceId })).ToList();
        }

        public Field GetById(Guid id)
        {
            const string Sql = @"
SELECT [Id], [ResourceId], [Name], [Type], [IsRequired], [IsUnique], [IsEncrypted]
FROM [restGenerator].[Field]
WHERE [Id] = @Id";

            return this.databaseConnectionString.Query(db => db.Query<Field>(Sql, new { Id = id }).SingleOrDefault());
        }

        public Field Save(Field field)
        {
            const string Sql = @"
INSERT INTO [restGenerator].[Field]
 ([Id], [ResourceId], [Name], [Type], [IsRequired], [IsUnique], [IsEncrypted])
VALUES
 (@Id, @ResourceId, @Name, @Type, @IsRequired, @IsUnique, @IsEncrypted)

SELECT [Id], [ResourceId], [Name], [Type], [IsRequired], [IsUnique], [IsEncrypted]
FROM [restGenerator].[Field]
WHERE [Id] = @Id";

            if (field.Id == Guid.Empty)
            {
                field.Id = Guid.NewGuid();
            }

            return this.databaseConnectionString.Query(db => db.Query<Field>(Sql, field).SingleOrDefault());
        }

        public Field Update(Guid id, Field field)
        {
            const string Sql = @"
UPDATE [restGenerator].[Field]
SET [ResourceId] = @ResourceId,
    [Name] = @Name,
    [Type] = @Type,
    [IsRequired] = @IsRequired,
    [IsUnique] = @IsEncrypted
WHERE [Id] = @Id

SELECT [Id], [ResourceId], [Name], [Type], [IsRequired], [IsUnique], [IsEncrypted]
FROM [restGenerator].[Field]
WHERE [Id] = @Id";

            field.Id = id;

            return this.databaseConnectionString.Query(db => db.Query<Field>(Sql, field).SingleOrDefault());
        }

        public void DeleteAll(Guid resourceId)
        {
            const string Sql = "DELETE [restGenerator].[Field] WHERE [ResourceId] = @ResourceId";

            this.databaseConnectionString.Execute(db => db.Execute(Sql, new { ResourceId = resourceId }));
        }

        public void DeleteById(Guid id)
        {
            const string Sql = "DELETE [restGenerator].[Field] WHERE [Id] = @Id";

            this.databaseConnectionString.Execute(db => db.Execute(Sql, new { Id = id }));
        }
    }
}
