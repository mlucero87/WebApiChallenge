using Application.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public partial class ChallengeDbContext : DbContext, IChallengeDbContext
    {

        public ChallengeDbContext(DbContextOptions<ChallengeDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<ContactPhone> ContactPhones { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source=contacts.db");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
               .HasMany(e => e.Phones)
               .WithOne(e => e.Contact)
               .HasForeignKey(e => e.ContactId)
               .HasPrincipalKey(e => e.Id);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
