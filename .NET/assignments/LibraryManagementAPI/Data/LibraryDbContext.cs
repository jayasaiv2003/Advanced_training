using LibraryManagementAPI.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Data  
{
    public class LibraryDbContext : DbContext
    {
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }


    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{

    //    modelBuilder.ApplyConfiguration(new AuthorConfig());
    //    modelBuilder.ApplyConfiguration(new BookConfig());

    //}
}
}

