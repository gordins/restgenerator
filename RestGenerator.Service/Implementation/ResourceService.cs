using System;
using System.Collections.Generic;
using RestGenerator.DataAccess;
using RestGenerator.Service.Implementation.Mapper;
using RestGenerator.Service.Model;

namespace RestGenerator.Service.Implementation
{
    internal class ResourceService : IResourceService
    {
        private readonly IResourceRepository resourceRepository;

        public ResourceService(IResourceRepository resourceRepository)
        {
            this.resourceRepository = resourceRepository;
        }

        public List<Resource> GetAll(Guid apiId)
        {
            return this.resourceRepository.GetAll(apiId).ToModel();
        }

        public Resource GetById(Guid id)
        {
            return this.resourceRepository.GetById(id).ToModel();
        }

        public Resource Save(Resource resource)
        {
            return this.resourceRepository.Save(resource.ToEntity()).ToModel();
        }

        public Resource Update(Guid id, Resource resource)
        {
            return this.resourceRepository.Update(id, resource.ToEntity()).ToModel();
        }

        public void DeleteAll(Guid apiId)
        {
            this.resourceRepository.DeleteAll(apiId);
        }

        public void DeleteById(Guid id)
        {
            this.resourceRepository.DeleteById(id);
        }
    }
}
