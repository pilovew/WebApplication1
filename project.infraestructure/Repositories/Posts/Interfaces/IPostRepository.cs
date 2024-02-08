using project.domain.Posts;

namespace project.infraestructure.Repositories.Posts.Interfaces
{
    public interface IPostRepository
    {
        public Task<ICollection<Post>> GetAll();
        public Task<Post> Get(int Id);
        public Task<Post> Create(Post post);
        public Task<Post> Update(Post post);
        public Task<bool> Delete(int Id);
    }
    
    


}
