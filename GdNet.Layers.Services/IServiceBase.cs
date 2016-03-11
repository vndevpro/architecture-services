using GdNet.Common;
using GdNet.Layers.Dtos;
using System;
using System.Collections.Generic;

namespace GdNet.Layers.Services
{
    public interface IServiceBase<T> where T : EditableEntityDto
    {
        T GetById(Guid id);

        void ChangeState(Guid id, string newState);

        Result<T> Get(Page page);

        T Save(T entityDto);

        IList<T> Save(IEnumerable<T> entitiesDto);

        void Delete(Guid id);

        long Count();
    }
}
