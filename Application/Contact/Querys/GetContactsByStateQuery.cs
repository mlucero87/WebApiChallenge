using Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Contact.Querys
{
    public class GetContactsByStateQuery : IRequest<IEnumerable<Domain.Entities.Contact>>
    {
        public readonly string _state;
        public GetContactsByStateQuery(string state)
        {
            _state = state;
        }
    }
    public class GetContactsByStateQueryHandler : IRequestHandler<GetContactsByStateQuery, IEnumerable<Domain.Entities.Contact>>
    {

        private readonly IChallengeDbContext _context;
        public GetContactsByStateQueryHandler(IChallengeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.Contact>> Handle(GetContactsByStateQuery request, CancellationToken cancellationToken)
        {
            return await _context.Contacts.Include(x => x.Address).Where(x => x.Address.State == request._state).ToListAsync(cancellationToken);
        }
    }
}
