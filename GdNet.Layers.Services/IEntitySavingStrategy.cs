using GdNet.Domain.Entity;
using GdNet.Layers.Dtos;

namespace GdNet.Layers.Services
{
    public interface IEntitySavingStrategy<in TDto, in TEntity>
        where TDto : EditableEntityDto
        where TEntity : IAggregateRoot
    {
        void OnCreating(TEntity entity, TDto entityDto);

        void OnUpdating(TEntity entity, TDto entityDto);
    }
}