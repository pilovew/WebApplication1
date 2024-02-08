
namespace project.application.Posts.Models
{
    public class PostCreationDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public bool Favoritos { get; set; }
        public int Prioridad { get; set; }

        public ICollection<int> TagsIds { get; set; }
    }
}
