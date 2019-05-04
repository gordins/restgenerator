using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using RestGenerator.Service;
using RestGenerator.Service.Model;

namespace RestGenerator.Web.Controllers
{
    [Route("api/[Controller]")]
    public class ApiController : Controller
    {
        private readonly IApiService apiService;

        public ApiController(IApiService apiService)
        {
            this.apiService = apiService;
        }

        [HttpGet]
        public List<Api> GetAll()
        {
            return this.apiService.GetAll();
        }

        [HttpGet("{id}")]
        public Api Get(Guid id)
        {
            return this.apiService.GetById(id);
        }

        [HttpPost]
        public Api Save([FromBody]Api api)
        {
            return this.apiService.Save(api);
        }

        [HttpPut("{id}")]
        public Api Update(Guid id, [FromBody]Api api)
        {
            return this.apiService.Update(id, api);
        }

        [HttpDelete]
        public void DeleteAll()
        {
            this.apiService.DeleteAll();
        }

        [HttpDelete("{id}")]
        public void DeleteById(Guid id)
        {
            this.apiService.DeleteById(id);
        }
    }
}
