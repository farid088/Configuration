using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(b => b.ISBN)
            .IsRequired()   
           .HasMaxLength(13);
        builder.Property(b => b.PublishedYear)
            .IsRequired();
        builder.Property(b => b.Price)
            .IsRequired();
        builder.HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId);
        builder.HasOne(b=> b.Category)
            .WithMany(c => c.Books)
            .HasForeignKey(b => b.CategoryId);
        builder.HasMany(b => b.Borrowings)
            .WithOne(r => r.Book)
            .HasForeignKey(r => r.BookId);

    }
}