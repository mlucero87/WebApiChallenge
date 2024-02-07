using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WebApi.Controllers;
using WebApi.Validators;

namespace WebApi.Test
{
    public class ContactControllerTest
    {
        protected Mock<ISender> _mediator;
        protected Mock<ILogger<ContactController>> _logger;
        protected ContactValidator _validator;

        public ContactControllerTest()
        {
            _mediator = new Mock<ISender>();
            _logger = new Mock<ILogger<ContactController>>();
            _validator = new ContactValidator();
        }

        [Fact]
        public async void Should_GetAll_Contacts_ResponseOk()
        {
            var controller = new ContactController(_logger.Object, _mediator.Object, _validator);

            var response = await controller.GetAll();

            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async void Should_GetByEmailOrPhone_ResponseOk()
        {
            var controller = new ContactController(_logger.Object, _mediator.Object, _validator);

            var response = await controller.GetByEmailOrPhone("test@test.com", null);

            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async void Should_GetByCity_ResponseOk()
        {
            var controller = new ContactController(_logger.Object, _mediator.Object, _validator);

            var response = await controller.GetContactsByCity("Buenos Aires");

            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async void Should_GetByState_ResponseOk()
        {
            var controller = new ContactController(_logger.Object, _mediator.Object, _validator);

            var response = await controller.GetContactsByState("La Plata");

            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async void Should_CreateContact_Failure()
        {
            var controller = new ContactController(_logger.Object, _mediator.Object, _validator);

            var response = await controller.Create(new Contact());

            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public async void Should_CreateContact_Ok()
        {
            var controller = new ContactController(_logger.Object, _mediator.Object, _validator);

            var response = await controller.Create(new Utils().GetFakeContactForCreate());

            Assert.IsType<OkObjectResult>(response.Result);
        }

    }
}