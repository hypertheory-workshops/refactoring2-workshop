using Microsoft.EntityFrameworkCore;

namespace TopicsApi.Data;

public class TopicsDataContext : DbContext
{
    public TopicsDataContext(DbContextOptions<TopicsDataContext> context): base(context)
    {

    }
    public DbSet<Topic>? Topics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Topic>()
            .Property(t => t.Description)
            .HasMaxLength(20);

        modelBuilder.Entity<Topic>()
            .HasData(
                new Topic {  Id=1, Description="Kubernetes"},
                new Topic { Id=2, Description="Docker"},
                new Topic {  Id =3, Description="DevOps"}

            );
        
    }
}

public class Topic
{
    public int Id { get; set; }
    public string Description { get; set; } = String.Empty;
}
