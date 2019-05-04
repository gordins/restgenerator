using System;
using System.Collections.Generic;
using RestGenerator.Service.Model;

namespace RestGenerator.Service
{
    public interface IFieldService
    {
        List<Field> GetAll(Guid resourceId);

        Field GetById(Guid id);

        Field Save(Field field);

        Field Update(Guid id, Field field);

        void DeleteAll(Guid resourceId);

        void DeleteById(Guid id);
    }
}
