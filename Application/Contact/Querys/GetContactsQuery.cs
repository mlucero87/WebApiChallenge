using Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Contact.Querys
{
    public class GetContactsQuery : IRequest<IEnumerable<Domain.Entities.Contact>>
    {
        public GetContactsQuery()
        {
        }
    }
    public class GetClienteHorariosQueryHandler : IRequestHandler<GetContactsQuery, IEnumerable<Domain.Entities.Contact>>
    {

        private readonly IChallengeDbContext _context;
        public GetClienteHorariosQueryHandler(IChallengeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.Contact>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Contacts.Include(x => x.Address).ToListAsync();
        }
    }
}
