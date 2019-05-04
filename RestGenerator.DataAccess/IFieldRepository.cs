using System;
using System.Collections.Generic;
using RestGenerator.Entity;

namespace RestGenerator.DataAccess
{
    public interface IFieldRepository
    {
        List<Field> GetAll(Guid resourceId);

        Field GetById(Guid id);

        Field Save(Field field);

        Field Update(Guid id, Field field);

        void DeleteAll(Guid resourceId);

        void DeleteById(Guid id);
    }
}
