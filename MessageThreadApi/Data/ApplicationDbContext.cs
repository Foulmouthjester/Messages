using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Message> Messages { get; set; }
    public DbSet<MessageThread> MessageThreads { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message>()
            .HasOne(m => m.MessageThread)
            .WithMany(mt => mt.Messages)
            .HasForeignKey(m => m.ThreadId);
    }
}