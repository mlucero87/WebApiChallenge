using Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Contact.Commands
{
    public class DeleteContactCommand : IRequest<bool>
    {
        public readonly int _id;

        public DeleteContactCommand(int id)
        {
            _id = id;
        }
    }

    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, bool>
    {
        private readonly IChallengeDbContext _context;

        public DeleteContactCommandHandler(IChallengeDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var Contact = await _context.Contacts.AsNoTracking().Where(x=> x.Id == request._id).FirstOrDefaultAsync();

            if (Contact == null)
            {
                throw new ApplicationException($"No existe el contacto con id: {request._id}");
            }

            _context.Contacts.Remove(Contact);

            await _context.SaveChangesAsync();

            return true ;
        }
    }
}
