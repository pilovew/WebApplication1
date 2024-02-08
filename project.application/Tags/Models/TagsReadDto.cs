

using project.application.Common;

namespace project.application.Tags.Models
{
    public class TagsReadDto : BaseDto
    {
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
