using System;
using System.Collections.Generic;
using RestGenerator.DataAccess;
using RestGenerator.Service.Implementation.Mapper;
using RestGenerator.Service.Model;

namespace RestGenerator.Service.Implementation
{
    internal class FieldService : IFieldService
    {
        private readonly IFieldRepository fieldRepository;

        public FieldService(IFieldRepository fieldRepository)
        {
            this.fieldRepository = fieldRepository;
        }

        public List<Field> GetAll(Guid resourceId)
        {
            return this.fieldRepository.GetAll(resourceId).ToModel();
        }

        public Field GetById(Guid id)
        {
            return this.fieldRepository.GetById(id).ToModel();
        }

        public Field Save(Field field)
        {
            return this.fieldRepository.Save(field.ToEntity()).ToModel();
        }

        public Field Update(Guid id, Field field)
        {
            return this.fieldRepository.Update(id, field.ToEntity()).ToModel();
        }

        public void DeleteAll(Guid resourceId)
        {
            this.fieldRepository.DeleteAll(resourceId);
        }

        public void DeleteById(Guid id)
        {
            this.fieldRepository.DeleteById(id);
        }
    }
}
