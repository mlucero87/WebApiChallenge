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
        private readonly ISender _sender;
        public ContactController(ILogger<ContactController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAll()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> Create([FromBody] Contact contact)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Contact>> Update([FromBody] Contact contact)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<Contact>> Delete([FromQuery] int id)
        {
            return Ok();
        }

    }
}
