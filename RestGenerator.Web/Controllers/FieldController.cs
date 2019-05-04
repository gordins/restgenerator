using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using RestGenerator.Service;
using RestGenerator.Service.Model;

namespace RestGenerator.Web.Controllers
{
    [Route("api/[Controller]")]
    public class FieldController : Controller
    {
        private readonly IFieldService fieldService;

        public FieldController(IFieldService fieldService)
        {
            this.fieldService = fieldService;
        }

        [HttpGet("all/{resourceId}")]
        public List<Field> GetAll(Guid resourceId)
        {
            return this.fieldService.GetAll(resourceId);
        }

        [HttpGet("{id}")]
        public Field Get(Guid id)
        {
            return this.fieldService.GetById(id);
        }

        [HttpPost]
        public Field Save([FromBody]Field field)
        {
            return this.fieldService.Save(field);
        }

        [HttpPut("{id}")]
        public Field Update(Guid id, [FromBody]Field field)
        {
            return this.fieldService.Update(id, field);
        }

        [HttpDelete("all/{resourceId}")]
        public void DeleteAll(Guid resourceId)
        {
            this.fieldService.DeleteAll(resourceId);
        }

        [HttpDelete("{id}")]
        public void DeleteById(Guid id)
        {
            this.fieldService.DeleteById(id);
        }
    }
}
