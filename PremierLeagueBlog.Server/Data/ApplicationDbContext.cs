using Microsoft.EntityFrameworkCore;
using PremierLeagueBlog.Server.Data.Models;

namespace PremierLeagueBlog.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Article> Articles => Set<Article>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    Id = 1,
                    Image = "sample1.png",
                    Title = "Sample Article Title 1",
                    Summary = "Sample summary of the article 1...",
                    Description = "Detailed description of the article 1...",
                    Date = DateTime.Now.AddDays(-1)
                },
                new Article
                {
                    Id = 2,
                    Image = "sample1.png",
                    Title = "Sample Article Title 2",
                    Summary = "Sample summary of the article 2...",
                    Description = "Detailed description of the article 2...",
                    Date = DateTime.Now.AddDays(-2)
                },
                new Article
                {
                    Id = 3,
                    Image = "sample1.png",
                    Title = "Sample Article Title 3",
                    Summary = "Sample summary of the article 3...",
                    Description = "Detailed description of the article 3...",
                    Date = DateTime.Now.AddDays(-3)
                },
                new Article
                {
                    Id = 4,
                    Image = "sample1.png",
                    Title = "Sample Article Title 4",
                    Summary = "Sample summary of the article 4...",
                    Description = "Detailed description of the article 4...",
                    Date = DateTime.Now.AddDays(-4)
                },
                new Article
                {
                    Id = 5,
                    Image = "sample1.png",
                    Title = "Sample Article Title 5",
                    Summary = "Sample summary of the article 5...",
                    Description = "Detailed description of the article 5...",
                    Date = DateTime.Now.AddDays(-5)
                },
                new Article
                {
                    Id = 6,
                    Image = "sample1.png",
                    Title = "Sample Article Title 6",
                    Summary = "Sample summary of the article 6...",
                    Description = "Detailed description of the article 6...",
                    Date = DateTime.Now.AddDays(-6)
                },
                new Article
                {
                    Id = 7,
                    Image = "sample1.png",
                    Title = "Sample Article Title 7",
                    Summary = "Sample summary of the article 7...",
                    Description = "Detailed description of the article 7...",
                    Date = DateTime.Now.AddDays(-7)
                }
            );
        }
    }
}
