using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions
{
    public interface IChallengeDbContext
    {
        DbSet<Contact> Contacts { get; set; }
        DbSet<Address> Address { get; set; }
    }
}
