using Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Contact.Querys
{
    public class GetContactsByEmailOrPhoneQuery : IRequest<IEnumerable<Domain.Entities.Contact>>
    {
        public readonly string _Email = string.Empty;
        public readonly string _Phone = string.Empty;
        public GetContactsByEmailOrPhoneQuery(string email, string phone)
        {
            _Email = email;
            _Phone = phone;
        }
    }
    public class GetContactsByEmailOrPhoneQueryHandler : IRequestHandler<GetContactsByEmailOrPhoneQuery, IEnumerable<Domain.Entities.Contact>>
    {

        private readonly IChallengeDbContext _context;
        public GetContactsByEmailOrPhoneQueryHandler(IChallengeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.Contact>> Handle(GetContactsByEmailOrPhoneQuery request, CancellationToken cancellationToken)
        {


            var query = _context.Contacts.Include(x => x.Address).Include(x => x.Phones).AsQueryable();

            if (!string.IsNullOrEmpty(request._Email) && !string.IsNullOrEmpty(request._Phone))
            {

                query = query.Where(x => x.Email == request._Email || x.Phones.Any(p => p.Number == request._Phone));

                return await query.ToListAsync(cancellationToken);
            }

            if (!string.IsNullOrEmpty(request._Email))
            {
                query = query.Where(x => x.Email == request._Email);
            }

            if (!string.IsNullOrEmpty(request._Phone))
            {
                query = query.Where(x => x.Phones.Any(p => p.Number == request._Phone));
            }

            return await query.ToListAsync(cancellationToken);
        }
    }
}
