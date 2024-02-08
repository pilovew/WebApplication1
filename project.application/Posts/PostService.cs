using project.domain.Posts;
using project.application.Posts.Models;
using project.application.Posts.Interfaces;
using project.infraestructure.Repositories.Posts.Interfaces;

namespace project.application.Posts
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        
        public async Task<PostReadDto> Create(PostCreationDto post)
        {
            var postEntity = new Post {
                Prioridad = post.Prioridad,
                Nombre = post.Nombre,
                Descripcion = post.Descripcion,
                FechaPublicacion = post.FechaPublicacion,
                Favoritos = post.Favoritos
            };
            

            postEntity = await _postRepository.Create(postEntity);

            var mappedEntity = new PostReadDto
            {
                Id = postEntity.Id,
                Nombre = postEntity.Nombre
            };

            return mappedEntity;

        }

        public async Task<bool> Delete(int Id)
        {
            var result = await _postRepository.Delete(Id);
            return result;
        }

        public async Task<PostReadDto> Get(int Id)
        {
            var postEntity = await _postRepository.Get(Id);
            var mappedEntity = new PostReadDto
            {
                Id = postEntity.Id,
                Nombre = postEntity.Nombre
            };
            return mappedEntity;
        }

        public async Task<ICollection<PostReadDto>> GetAll()
        {
            var postEntities = await _postRepository.GetAll();
            return postEntities.Select(x => new PostReadDto
            {
                Id = x.Id,
                Nombre = x.Nombre
            }).ToList();
        }

        public async Task<PostReadDto> Update(PostReadDto post)
        {
            var entityToUpdate = await _postRepository.Get(post.Id);


            entityToUpdate.Id = post.Id;
            entityToUpdate.Nombre = post.Nombre;

            entityToUpdate = await _postRepository.Update(entityToUpdate);
            var mappedEntity = new PostReadDto
            {
                Id = entityToUpdate.Id,
                Nombre = entityToUpdate.Nombre,
                Descripcion = entityToUpdate.Descripcion,
                FechaPublicacion = entityToUpdate.FechaPublicacion,
                Favoritos = entityToUpdate.Favoritos
            };
            return mappedEntity;
        }

    }
}
