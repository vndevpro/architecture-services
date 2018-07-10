using GdNet.Domain.AppCommon;
using GdNet.Layers.AppCommon.Services;
using GdNet.Layers.AutoMapper;

namespace GdNet.Layers.AppCommon.ServicesImpl.Mappers
{
    public class AttachmentDtoMapperFactory : DefaultEditableEntityDtoMapperFactory<Attachment, AttachmentDto>
    {
        protected override void OnMapperCreated()
        {
            base.OnMapperCreated();

            MappingExpression
                .ForMember(p => p.Note, a => a.MapFrom(p => p.Note));
        }
    }
}