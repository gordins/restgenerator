using System;
using System.Collections.Generic;
using RestGenerator.Entity;

namespace RestGenerator.DataAccess
{
    public interface IResourceRepository
    {
        List<Resource> GetAll(Guid apiId);

        Resource GetById(Guid id);

        Resource Save(Resource resource);

        Resource Update(Guid id, Resource resource);

        void DeleteAll(Guid apiId);

        void DeleteById(Guid id);
    }
}
