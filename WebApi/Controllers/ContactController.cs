using Application.Contact.Commands;
using Application.Contact.Querys;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly ISender _mediator;

        public ContactController(ILogger<ContactController> logger, ISender sender)
        {
            _logger = logger;
            _mediator = sender;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAll()
        {
            var response = await _mediator.Send(new GetContactsQuery());
            return Ok(response);
        }

        [HttpGet("SearchByEmailOrPhone")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetByEmailOrPhone([FromQuery] string? email, string? phone)
        {
            var response = await _mediator.Send(new GetContactsByEmailOrPhoneQuery(email, phone));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> Create([FromBody] Contact contact)
        {
            var response = await _mediator.Send(new CreateContactCommand(contact));
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<Contact>> Update([FromBody] Contact contact)
        {
            var response = await _mediator.Send(new UpdateContactCommand(contact));
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            await _mediator.Send(new DeleteContactCommand(id));
            return Ok();
        }

    }
}
