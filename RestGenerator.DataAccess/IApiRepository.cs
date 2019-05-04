using System;
using System.Collections.Generic;
using RestGenerator.Entity;

namespace RestGenerator.DataAccess
{
    public interface IApiRepository
    {
        List<Api> GetAll();

        Api GetById(Guid id);

        Api Save(Api api);

        Api Update(Guid id, Api api);

        void DeleteAll();

        void DeleteById(Guid id);
    }
}
