using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions
{
    public interface IChallengeDbContext
    {
        DbSet<Domain.Entities.Contact> Contacts { get; set; }
        DbSet<Domain.Entities.Address> Address { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
