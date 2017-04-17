using GdNet.Domain.AppCommon;
using GdNet.Layers.AppCommon.Services;
using GdNet.Layers.Services;
using Mapping.Common.Contracts;
using System;

namespace GdNet.Layers.AppCommon.ServicesImpl
{
    public class AttachmentService : ServiceBase<AttachmentDto, Attachment>, IAttachmentService
    {
        public AttachmentService(IAttachmentRepository repository, IMapperProvider mapperProvider)
            : base(repository, mapperProvider)
        {
        }

        public AttachmentService(IAttachmentRepository repository, IMapperProvider mapperProvider, IEntitySavingStrategy<AttachmentDto, Attachment> savingStrategy)
            : base(repository, mapperProvider, savingStrategy)
        {
        }

        public DetailAttachmentDto GetDetailById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
