using Domain.Models;
using Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public partial class ContactsDBContext : DbContext
{
    private readonly IConfiguration _configuration;
    public ContactsDBContext(DbContextOptions<ContactsDBContext> options, IConfiguration configuration)
            : base(options)
    {
        _configuration = configuration;
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("DBConnection");
        optionsBuilder.UseSqlite(connectionString);
    }
    public virtual DbSet<ContactInfo> ContactInfo{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ContactInfoEntityTypeConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
