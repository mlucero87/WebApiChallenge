using Application.Abstractions;
using MediatR;

namespace Application.Contact.Commands
{
    public class CreateContactCommand : IRequest<Domain.Entities.Contact?>
    {
        public readonly Domain.Entities.Contact _model;

        public CreateContactCommand(Domain.Entities.Contact request)
        {
            _model = request;
        }
    }

    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Domain.Entities.Contact?>
    {
        private readonly IChallengeDbContext _context;

        public CreateContactCommandHandler(IChallengeDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Contact?> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var Contact = await _context.Contacts.FindAsync(request._model.Id);

            if (Contact != null)
            {
                throw new ApplicationException($"ya existe el contacto con id: {request._model.Id}");
            }

            _context.Contacts.Add(request._model);

            await _context.SaveChangesAsync();

            return await _context.Contacts.FindAsync(request._model.Id);
        }
    }
}
