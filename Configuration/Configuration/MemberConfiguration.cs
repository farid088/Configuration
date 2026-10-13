using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.FullName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(m => m.Email)
            .IsRequired()
            .HasMaxLength(100); 
        builder.Property(m => m.PhoneNumber)
            .IsRequired();
        builder.Property(m => m.RegistrationDate)
            .IsRequired();
        
    }
}