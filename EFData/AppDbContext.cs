using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class AppDbContext : IdentityDbContext<IdentityUser>
{ 
    public DbSet<ContactEntity> Contacts { get; set; } 
    public DbSet<OrganizationEntity> Organizations { get; set; }
    private string DbPath { get; set; } 
    public AppDbContext() 
    { 
        var folder = Environment.SpecialFolder.LocalApplicationData; 
        var path = Environment.GetFolderPath(folder); 
        DbPath = System.IO.Path.Join(path, "contacts.db"); 
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"EFData Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
        
        string ADMIN_ID = Guid.NewGuid().ToString();
        string ROLE_ID = Guid.NewGuid().ToString();
        string USER_ROLE_ID = Guid.NewGuid().ToString();
        string USER_ID = Guid.NewGuid().ToString();
        
        modelBuilder.Entity<ContactEntity>()
            .HasOne(e => e.Organization)
            .WithMany(o => o.Contacts)
            .HasForeignKey(e => e.OrganizationId);

        modelBuilder.Entity<OrganizationEntity>()
            .ToTable("organizations")
            .HasData(
                new OrganizationEntity()
                {
                    Id = 101,
                    Title = "WSEI",
                    Nip = "83492384",
                    Regon = "13424234",
                },
                new OrganizationEntity()
                {
                    Id = 102,
                    Title = "Firma",
                    Nip = "2498534",
                    Regon = "0873439249",
                }
            ); ;
        modelBuilder.Entity<ContactEntity>().HasData(
            new ContactEntity()
            {
                Id = 1,
                Name = "AA",
                Email = "Adam",
                Phone = "13424234",
                OrganizationId = 1,

            },
            new ContactEntity()
            {
                Id = 2,
                Name = "C#",
                Email = "Ewa",
                Phone = "02879283",
                OrganizationId = 2,
            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });
                
            var admin = new IdentityUser
                {
                    Id = ADMIN_ID,
                    Email = "adam@wsei.edu.pl",
                    EmailConfirmed = true,
                    UserName = "adam",
                    NormalizedUserName = "ADMIN",
                    NormalizedEmail = "ADAM@WSEI.EDU.PL"
                };
                PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
                admin.PasswordHash = ph.HashPassword(admin, "1234abcd!@#$ABCD");
                modelBuilder.Entity<IdentityUser>().HasData(admin);
                
                modelBuilder.Entity<IdentityUserRole<string>>()
                    .HasData(new IdentityUserRole<string>
                    {
                        RoleId = ROLE_ID,
                        UserId = ADMIN_ID
                    });
                new IdentityUserRole<string>()
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID
                };
    }
    
} 