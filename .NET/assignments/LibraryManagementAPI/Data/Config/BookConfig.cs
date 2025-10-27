using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Data.Config
{
    public class BookConfig: IEntityTypeConfiguration<Book>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(b => b.BookId);
            builder.Property(b => b.Title).IsRequired().HasMaxLength(200);
            builder.Property(b => b.Genre).HasMaxLength(100);
            builder.HasData(new List<Book>
            {
               new Book {
                                BookId = 1,
                                Title = "The Dark Knight",
                                Genre = "Action",
                                AuthorId = 1
                                }
            });
        }
    }
}
