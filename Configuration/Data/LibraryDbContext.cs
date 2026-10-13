using Microsoft.EntityFrameworkCore;

public class LibraryDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Library;Trusted_Connection=True;TrustServerCertificate=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDbContext).Assembly);
        modelBuilder.Entity<Author>().HasKey(a => a.Id);
        modelBuilder.Entity<Book>().HasKey(b => b.Id);
        modelBuilder.Entity<Category>().HasKey(c => c.Id);
        modelBuilder.Entity<Member>().HasKey(m => m.Id);
        modelBuilder.Entity<Borrowing>().HasKey(b => b.Id);

        modelBuilder.Entity<Author>().ToTable("Authors");
        modelBuilder.Entity<Book>().ToTable("Books");
        modelBuilder.Entity<Category>().ToTable("Categories");
        modelBuilder.Entity<Member>().ToTable("Members");
        modelBuilder.Entity<Borrowing>().ToTable("Borrowings");

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Category)
            .WithMany(c => c.Books)
            .HasForeignKey(b => b.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        
        modelBuilder.Entity<Borrowing>()
            .HasOne(b => b.Member)
            .WithMany(m => m.Borrowings)
            .HasForeignKey(b => b.MemberId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Borrowing>()
            .HasOne(b => b.Book)
            .WithMany(book => book.Borrowings)
            .HasForeignKey(b => b.BookId)
            .OnDelete(DeleteBehavior.Cascade);
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Borrowing>()
        .Property(b => b.BorrowedDate)
        .IsRequired();

        modelBuilder.Entity<Borrowing>()
            .Property(b => b.DueDate)
            .IsRequired();

        modelBuilder.Entity<Borrowing>()
            .Property(b => b.ReturnedDate)
            .IsRequired(false);

        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Borrowing> Borrowings { get; set; }
}