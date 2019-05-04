using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using RestGenerator.Service;
using RestGenerator.Service.Model;

namespace RestGenerator.Web.Controllers
{
    [Route("api/[Controller]")]
    public class ResourceController : Controller
    {
        private readonly IResourceService resourceService;

        public ResourceController(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }

        [HttpGet("all/{apiId}")]
        public List<Resource> GetAll(Guid apiId)
        {
            return this.resourceService.GetAll(apiId);
        }

        [HttpGet("{id}")]
        public Resource Get(Guid id)
        {
            return this.resourceService.GetById(id);
        }

        [HttpPost]
        public Resource Save([FromBody]Resource resource)
        {
            return this.resourceService.Save(resource);
        }

        [HttpPut("{id}")]
        public Resource Update(Guid id, [FromBody]Resource resource)
        {
            return this.resourceService.Update(id, resource);
        }

        [HttpDelete("all/{apiId}")]
        public void DeleteAll(Guid apiId)
        {
            this.resourceService.DeleteAll(apiId);
        }

        [HttpDelete("{id}")]
        public void DeleteById(Guid id)
        {
            this.resourceService.DeleteById(id);
        }
    }
}
