using Microsoft.EntityFrameworkCore;

namespace ElectronicLibrary.Entity;

public class AppContext: DbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Book>? Books { get; set; }
    public DbSet<Genre>? Genres { get; set; }
    public DbSet<Author>? Authors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Database=ElectronicLibrary;Encrypt=False;Trusted_Connection=True;");
    }
}