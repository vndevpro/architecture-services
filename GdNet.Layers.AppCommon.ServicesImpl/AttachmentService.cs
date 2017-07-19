using GdNet.Domain.AppCommon;
using GdNet.Layers.AppCommon.Services;
using GdNet.Layers.Services;
using Mapping.Common.Contracts;
using System;

namespace GdNet.Layers.AppCommon.ServicesImpl
{
    public class AttachmentService : ServiceBase<AttachmentDto, Attachment>, IAttachmentService
    {
        private readonly IAttachmentRepository _repository;

        public AttachmentService(IAttachmentRepository repository, IMapperProvider mapperProvider)
            : base(repository, mapperProvider)
        {
            _repository = repository;
        }

        public AttachmentService(IAttachmentRepository repository, IMapperProvider mapperProvider, IEntitySavingStrategy<AttachmentDto, Attachment> savingStrategy)
            : base(repository, mapperProvider, savingStrategy)
        {
            _repository = repository;
        }

        public DetailAttachmentDto GetDetailById(Guid id)
        {
            var attachment = _repository.GetById(id);
            return MapperProvider.Map(attachment, new DetailAttachmentDto());
        }
    }
}
