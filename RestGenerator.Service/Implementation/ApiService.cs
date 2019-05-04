using System;
using System.Collections.Generic;
using RestGenerator.DataAccess;
using RestGenerator.Service.Implementation.Mapper;
using RestGenerator.Service.Model;

namespace RestGenerator.Service.Implementation
{
    internal class ApiService : IApiService
    {
        private readonly IApiRepository apiRepository;
        private readonly IResourceRepository resourceRepository;

        public ApiService(IApiRepository apiRepository, IResourceRepository resourceRepository)
        {
            this.apiRepository = apiRepository;
            this.resourceRepository = resourceRepository;
        }

        public List<Api> GetAll()
        {
            var apis = this.apiRepository.GetAll();
            apis.ForEach(api => api.Resources = this.resourceRepository.GetAll(api.Id));
            return apis.ToModel();
        }

        public Api GetById(Guid id)
        {
            var api = this.apiRepository.GetById(id);
            api.Resources = this.resourceRepository.GetAll(api.Id);
            return api.ToModel();
        }

        public Api Save(Api api)
        {
            return this.apiRepository.Save(api.ToEntity()).ToModel();
        }

        public Api Update(Guid id, Api api)
        {
            return this.apiRepository.Update(id, api.ToEntity()).ToModel();
        }

        public void DeleteAll()
        {
            this.apiRepository.DeleteAll();
        }

        public void DeleteById(Guid id)
        {
            this.apiRepository.DeleteById(id);
        }
    }
}
