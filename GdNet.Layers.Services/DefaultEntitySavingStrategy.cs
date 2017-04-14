using GdNet.Domain.Entity;
using GdNet.Layers.Dtos;

namespace GdNet.Layers.Services
{
    /// <summary>
    /// Default implement of saving strategy - do nothing
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public class DefaultEntitySavingStrategy<TDto, TEntity> : IEntitySavingStrategy<TDto, TEntity>
        where TDto : EditableEntityDto
        where TEntity : IAggregateRoot
    {
        public virtual void OnCreating(TEntity entity, TDto entityDto)
        {
        }

        public virtual void OnUpdating(TEntity entity, TDto entityDto)
        {
        }
    }
}