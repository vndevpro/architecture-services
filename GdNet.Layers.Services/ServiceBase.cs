using GdNet.Common;
using GdNet.Domain.Entity;
using GdNet.Domain.Repository;
using GdNet.Layers.Dtos;
using Mapping.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GdNet.Layers.Services
{
    public abstract class ServiceBase<TDto, TEntity> : IServiceBase<TDto>
        where TDto : EditableEntityDto, new()
        where TEntity : IAggregateRoot, new()
    {
        private readonly IRepositoryBase<TEntity> _repository;
        private readonly IEntitySavingStrategy<TDto, TEntity> _savingStrategy;
        private readonly IMapperProvider _mapperProvider;

        public IMapperProvider MapperProvider
        {
            get { return _mapperProvider; }
        }

        protected ServiceBase(IRepositoryBase<TEntity> repository, IMapperProvider mapperProvider)
            : this(repository, mapperProvider, new DefaultEntitySavingStrategy<TDto, TEntity>())
        {
        }

        protected ServiceBase(IRepositoryBase<TEntity> repository,
            IMapperProvider mapperProvider,
            IEntitySavingStrategy<TDto, TEntity> savingStrategy)
        {
            _repository = repository;
            _mapperProvider = mapperProvider;
            _savingStrategy = savingStrategy;
        }

        public TDto GetById(Guid id)
        {
            var entity = _repository.GetById(id);
            return MapperProvider.Map(entity, new TDto());
        }

        public void ChangeState(Guid id, string newState)
        {
            var entity = _repository.GetById(id);
            entity.ChangeState(newState);
        }

        public Result<TDto> Get(Page page)
        {
            var results = _repository.Get(page);
            return results.ConvertTo(e => MapperProvider.Map(e, new TDto()));
        }

        public TDto Save(TDto entityDto)
        {
            TEntity entity;

            if (entityDto.Id == Guid.Empty)
            {
                entity = MapperProvider.Map(entityDto, new TEntity());
                _savingStrategy.OnCreating(entity, entityDto);
            }
            else
            {
                entity = _repository.GetById(entityDto.Id);
                MapperProvider.Map(entityDto, entity);
                _savingStrategy.OnUpdating(entity, entityDto);
            }

            _repository.Save(entity);

            return MapperProvider.Map(entity, new TDto());
        }

        public IList<TDto> Save(IEnumerable<TDto> entitiesDto)
        {
            return entitiesDto.Select(Save).ToList();
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public long Count()
        {
            return _repository.Count();
        }
    }
}
