using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    public class ContactInfoEntityTypeConfiguration : IEntityTypeConfiguration<ContactInfo>
    {
        public void Configure(EntityTypeBuilder<ContactInfo> entity)
        {
            entity.Property(e => e.Id).HasColumnOrder(1).HasColumnType("VARCHAR (36)");

            entity.Property(e => e.FirstName).HasColumnOrder(2).IsRequired().HasColumnType("VARCHAR");

            entity.Property(e => e.LastName).HasColumnOrder(3).IsRequired().HasColumnType("VARCHAR");

            entity.Property(e => e.EmployeeRegistrationNumber).HasColumnOrder(4).IsRequired().HasColumnType("INT");

            entity.Property(e => e.Department).HasColumnOrder(5).IsRequired().HasColumnType("VARCHAR");

            entity.Property(e => e.Location).HasColumnOrder(7).HasColumnType("VARCHAR");

            entity.Property(e => e.Position).HasColumnOrder(8).HasColumnType("VARCHAR");

            entity.Property(e => e.WorkPhoneNumber).HasColumnOrder(9).IsRequired().HasColumnType("VARCHAR");

            entity.Property(e => e.OtherWorkPhoneNumber).HasColumnOrder(10).HasColumnType("VARCHAR"); 

            entity.Property(e => e.CorporatePhoneNumber).HasColumnOrder(11).HasColumnType("VARCHAR");

            entity.Property(e => e.WalkieTalkieNumber).HasColumnOrder(12).HasColumnType("VARCHAR");

            entity.Property(e => e.Email).IsRequired().HasColumnOrder(13).IsRequired().HasColumnType("VARCHAR");

            entity.Property(e => e.InsertedDate)
                .IsRequired().HasColumnOrder(14)
                .HasColumnType("DATETIME");

            entity.Property(e => e.UpdatedDate).HasColumnOrder(14).HasColumnType("DATETIME");

            entity.Property(e => e.IsDeleted)
                .IsRequired().HasColumnOrder(15)
                .HasColumnType("BOOLEAN");

        }
    }
}
