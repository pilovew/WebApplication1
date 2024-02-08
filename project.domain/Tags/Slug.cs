using project.domain.Common;

namespace project.domain.Tags
{
    public class Slug : AuditEntity
    {
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }

        public ICollection<Slug> Slugs { get; set; }

    }
}
