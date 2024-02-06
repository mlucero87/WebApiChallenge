using Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Contact.Querys
{
    public class GetContactsByCityQuery : IRequest<IEnumerable<Domain.Entities.Contact>>
    {
        public readonly string _city;
        public GetContactsByCityQuery(string city)
        {
            _city = city;
        }
    }
    public class GetContactsByCityQueryHandler : IRequestHandler<GetContactsByCityQuery, IEnumerable<Domain.Entities.Contact>>
    {

        private readonly IChallengeDbContext _context;
        public GetContactsByCityQueryHandler(IChallengeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.Contact>> Handle(GetContactsByCityQuery request, CancellationToken cancellationToken)
        {
            return await _context.Contacts
                .Include(x => x.Address)
                .Include(x => x.Phones)
                .Where(x => x.Address.City == request._city).ToListAsync(cancellationToken);
        }
    }
}
