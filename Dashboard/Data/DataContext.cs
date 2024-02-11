using Dashboard.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder db)
        {

            base.OnModelCreating(db);
        }
        public DbSet<RssFeed> RssFeeds { get; set; }
        public DbSet<RssArticle> RssArticles { get; set; }
    }
}