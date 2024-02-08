

using project.application.Posts.Models;

namespace project.application.Posts.Interfaces
{
    public interface IPostService
    {
        public Task<ICollection<PostReadDto>> GetAll();
        public Task<PostReadDto> Get(int Id);
        public Task<PostReadDto> Create(PostCreationDto post);
        public Task<PostReadDto> Update(PostReadDto post);
        public Task<bool> Delete(int Id);
    }
}
