using System;
using System.Collections.Generic;
using RestGenerator.Service.Model;

namespace RestGenerator.Service
{
    public interface IResourceService
    {
        List<Resource> GetAll(Guid apiId);

        Resource GetById(Guid id);

        Resource Save(Resource resource);

        Resource Update(Guid id, Resource resource);

        void DeleteAll(Guid apiId);

        void DeleteById(Guid id);
    }
}
