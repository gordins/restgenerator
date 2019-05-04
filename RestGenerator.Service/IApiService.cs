using System;
using System.Collections.Generic;
using RestGenerator.Service.Model;

namespace RestGenerator.Service
{
    public interface IApiService
    {
        List<Api> GetAll();

        Api GetById(Guid id);

        Api Save(Api api);

        Api Update(Guid id, Api api);

        void DeleteAll();

        void DeleteById(Guid id);
    }
}
