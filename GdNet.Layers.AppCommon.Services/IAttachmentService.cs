using GdNet.Layers.Services;
using System;

namespace GdNet.Layers.AppCommon.Services
{
    public interface IAttachmentService : IServiceBase<AttachmentDto>
    {
        DetailAttachmentDto GetDetailById(Guid id);
    }
}