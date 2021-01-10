using System.Data.Entity;

namespace SimpleApplication.EF
{
    public class BloggingContext : DbContext
    {
        public BloggingContext():base("BloggingContext")
        {
            Database.SetInitializer<BloggingContext>(new CreateDatabaseIfNotExists<BloggingContext>());
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}