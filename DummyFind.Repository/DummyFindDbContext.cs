using Microsoft.EntityFrameworkCore;

namespace DummyFind.Persistance;
public class DummyFindDbContext : DbContext
{
    private string _connectionString;

    public DummyFindDbContext()
    {
    }

    public DbSet<PostsData> Posts { get; set; }
    public DbSet<UserData> Users { get; set; }

    //TODO Use IConfiguration and have these settings set at least on a appsettings file. Ideally we could use
    // a keyvault since this is sensitive information
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure your PostgreSQL connection here
        optionsBuilder.UseNpgsql("postgres://lubgcxht:Ckcyz7tTamD5zcbYHeO7XNp9BDABa4ec@trumpet.db.elephantsql.com/lubgcxht");
    }
}
