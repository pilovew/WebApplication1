using Microsoft.EntityFrameworkCore;
using project.domain.Posts;
using project.infraestructure.Data;
using project.infraestructure.Repositories.Posts.Interfaces;

namespace project.infraestructure.Repositories.Posts
{
    public class PostRepository : IPostRepository
    {
        private readonly projectContext _context;
        
        public PostRepository(projectContext context)
        {
            _context = context;
        }
        
        public async Task<Post> Create(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<bool> Delete(int Id)
        {
            var postEntity = await _context.Posts.FirstAsync(x => x.Id == Id);
            _context.Posts.Remove(postEntity);

            var isDeleted = await _context.SaveChangesAsync() > 0;
            return isDeleted;

        }

        public async Task<Post> Get(int Id)
        {
            var postEntity = await _context.Posts.FirstAsync(x => x.Id == Id);

            return postEntity;
        }

        public async Task<ICollection<Post>> GetAll()
        {
            var postEntities = await _context.Posts.ToListAsync();

            return postEntities;
        }

        public async Task<Post> Update(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();

            return post;
        }
    }
}
