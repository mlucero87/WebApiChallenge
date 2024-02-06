using Application.Abstractions;
using Application.Contact.Commands;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;

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
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
           
            var command = new CreateContactCommandHandler(_context);
            
            var response = await command.Handle(new CreateContactCommand(GetFakeContact()), token);
         
            Assert.True(response.Id > 0);
        }

        private Contact GetFakeContact()
        {
            return new Contact()
            {
                Name = "Jhon",
                Company = "Google",
                Birthdate = new DateTime(2000,3,1),
                Email = "jhon@gmail.com",
                Image = "",
                PersonalPhoneNumber = "123456",
                WorkPhoneNumber = "123456",
                Profile = "Developer",
                Address = new Address()
                {
                    State = "Buenos Aires",
                    Street = "Calle 1 1234",
                    Country = "Argentina",
                    City = "La Plata",
                    ZipCode = "1234",
                }
            };
        }
    }
}