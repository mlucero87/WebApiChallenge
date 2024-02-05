using Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Contact.Commands
{
    public class UpdateContactCommand : IRequest<Domain.Entities.Contact?>
    {
        public readonly Domain.Entities.Contact _model;

        public UpdateContactCommand(Domain.Entities.Contact request)
        {
            _model = request;
        }
    }

    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Domain.Entities.Contact?>
    {
        private readonly IChallengeDbContext _context;

        public UpdateContactCommandHandler(IChallengeDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Contact?> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var Contact = await _context.Contacts.AsNoTracking().Where(x=> x.Id == request._model.Id).FirstOrDefaultAsync();

            if (Contact == null)
            {
                throw new Exception(@"No existe el contacto {request._model.Id}");
            }

            _context.Contacts.Update(request._model);

            await _context.SaveChangesAsync();

            return await _context.Contacts.FindAsync(request._model.Id);
        }
    }
}
