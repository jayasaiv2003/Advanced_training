using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementAPI.Data.Config
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>


    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
            builder.HasKey(a => a.AuthorID);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Country).HasMaxLength(100);

            builder.HasData(new List<Author>
            {
               new Author {
                                AuthorID = 1,
                                Name = "blackpan",
                                Country = "gotham",
                                }
            });
        }   
    }
}
