using GdNet.Domain.Entity;
using GdNet.Layers.Dtos;

namespace GdNet.Layers.Services
{
    public interface IEntitySavingStrategy<in TDto, in TEntity>
        where TDto : EditableEntityDto
        where TEntity : IAggregateRoot
    {
        /// <summary>
        /// Logic will be executed before a new entity is saving into db
        /// </summary>
        void OnCreating(TEntity entity, TDto entityDto);

        /// <summary>
        /// Logic will be executed before an existing entity is updating into db
        /// </summary>
        void OnUpdating(TEntity entity, TDto entityDto);
    }
}