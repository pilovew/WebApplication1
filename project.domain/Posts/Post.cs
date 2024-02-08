using project.domain.Common;

namespace project.domain.Posts
{
    public class Post : AuditEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public bool Favoritos { get; set; }
        public int Prioridad { get; set; }

    }
}
