using System.Collections.Generic;
using System.Linq;
using RestGenerator.Entity;
using RestGenerator.Entity.Enums;

namespace RestGenerator.Service.Implementation.Mapper
{
    internal static class ToEntityMapper
    {
        public static List<Api> ToEntity(this List<Model.Api> apis)
        {
            return apis?.Select(api => api.ToEntity()).ToList();
        }

        public static Api ToEntity(this Model.Api api)
        {
            return api == null ? null : new Api
            {
                Id = api.Id,
                Name = api.Name,
                EncryptionKey = api.EncryptionKey,
                DecryptionKey = api.DecryptionKey,
                IsActive = api.IsActive,
                Resources = api.Resources.ToEntity()
            };
        }

        public static List<Resource> ToEntity(this List<Model.Resource> resources)
        {
            return resources?.Select(resource => resource.ToEntity()).ToList();
        }

        public static Resource ToEntity(this Model.Resource resource)
        {
            return resource == null ? null : new Resource
            {
                Id = resource.Id,
                ApiId = resource.ApiId,
                Name = resource.Name,
                Fields = resource.Fields.ToEntity()
            };
        }

        public static List<Field> ToEntity(this List<Model.Field> fields)
        {
            return fields?.Select(field => field.ToEntity()).ToList();
        }

        public static Field ToEntity(this Model.Field field)
        {
            return field == null ? null : new Field
            {
                Id = field.Id,
                ResourceId = field.ResourceId,
                Name = field.Name,
                Type = (FieldType) field.Type,
                IsEncrypted = field.IsEncrypted,
                IsRequired = field.IsRequired,
                IsUnique = field.IsUnique
            };
        }
    }
}
