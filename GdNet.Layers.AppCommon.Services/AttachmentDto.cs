using GdNet.Layers.Dtos;

namespace GdNet.Layers.AppCommon.Services
{
    public class AttachmentDto : EditableEntityDto
    {
        public string Name { get; set; }

        public string Extension { get; set; }

        public string ContentType { get; set; }

        public long Size { get; set; }

        public string OriginalFilePath { get; set; }

        public string AttributesData { get; set; }
    }
}
