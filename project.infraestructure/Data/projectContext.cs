

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using project.domain.Posts;
using project.domain.Tags;

namespace project.infraestructure.Data
{
    public class projectContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {

        public DbSet<Post> Posts { get; set; }
        public DbSet<Slug> Tags { get; set; }


        public projectContext(DbContextOptions<projectContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
