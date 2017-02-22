using GdNet.Domain.Entity;
using GdNet.Layers.Dtos;

namespace GdNet.Layers.Services
{
    /// <summary>
    /// Provides interceptions on creating / updating entity 
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public interface IEntitySavingStrategy<in TDto, in TEntity>
        where TDto : EditableEntityDto
        where TEntity : IAggregateRoot
    {
        void OnCreating(TEntity entity, TDto entityDto);

        void OnUpdating(TEntity entity, TDto entityDto);
    }
}