using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WebApi.Controllers;

namespace WebApi.Test
{
    public class ContactControllerTest
    {
        protected Mock<ISender> _mediator;
        protected Mock<ILogger<ContactController>> _logger;

        public ContactControllerTest()
        {
            _mediator = new Mock<ISender>();
            _logger = new Mock<ILogger<ContactController>>();
        }

        [Fact]
        public async void Should_GetAll_Contacts_ResponseOk()
        {
            var controller = new ContactController(_logger.Object, _mediator.Object);

            var response = await controller.GetAll();

            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async void Should_GetByEmailOrPhone_ResponseOk()
        {
            var controller = new ContactController(_logger.Object, _mediator.Object);

            var response = await controller.GetByEmailOrPhone("test@test.com", null);

            Assert.IsType<OkObjectResult>(response.Result);
        }

    }
}