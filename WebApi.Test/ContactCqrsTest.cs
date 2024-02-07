using Application.Contact.Commands;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Test
{
    public class ContactCQRSTest
    {

        private readonly ChallengeDbContext _context;
        public ContactCQRSTest()
        {
            var options = new DbContextOptionsBuilder<ChallengeDbContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString())
               .EnableSensitiveDataLogging()
               .Options;

            _context = new ChallengeDbContext(options);

        }

        [Fact]
        public async void Should_CreateCommand_Ok()
        {
            CancellationTokenSource source =  new CancellationTokenSource();
            CancellationToken token = source.Token;

            var command = new CreateContactCommandHandler(_context);

            var response = await command.Handle(new CreateContactCommand(new Utils().GetFakeContactForCreate()), token);

            Assert.True(response.Id > 0);
        }

        
    }
}