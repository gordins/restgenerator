using System.Collections.Generic;
using System.Linq;
using RestGenerator.Service.Model;

namespace RestGenerator.Service.Implementation.Mapper
{
    internal static class ToModelMapper
    {
        public static List<Api> ToModel(this List<Entity.Api> apis)
        {
            return apis?.Select(api => api.ToModel()).ToList();
        }

        public static Api ToModel(this Entity.Api api)
        {
            return api == null ? null : new Api
            {
                Id = api.Id,
                Name = api.Name,
                EncryptionKey = api.EncryptionKey,
                DecryptionKey = api.DecryptionKey,
                IsActive = api.IsActive,
                Resources = api.Resources.ToModel()
            };
        }

        public static List<Resource> ToModel(this List<Entity.Resource> resources)
        {
            return resources?.Select(resource => resource.ToModel()).ToList();
        }

        public static Resource ToModel(this Entity.Resource resource)
        {
            return resource == null ? null : new Resource
            {
                Id = resource.Id,
                ApiId = resource.ApiId,
                Name = resource.Name,
                Fields = resource.Fields.ToModel()
            };
        }

        public static List<Field> ToModel(this List<Entity.Field> fields)
        {
            return fields?.Select(field => field.ToModel()).ToList();
        }

        public static Field ToModel(this Entity.Field field)
        {
            return field == null ? null : new Field
            {
                Id = field.Id,
                ResourceId = field.ResourceId,
                Name = field.Name,
                Type = (int)field.Type,
                IsEncrypted = field.IsEncrypted,
                IsRequired = field.IsRequired,
                IsUnique = field.IsUnique
            };
        }
    }
}
