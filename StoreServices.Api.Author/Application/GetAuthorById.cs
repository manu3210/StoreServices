using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Author.Model;
using StoreServices.Api.Author.Persistance;

namespace StoreServices.Api.Author.Application
{
    public class GetAuthorById
    {
        public record Query(string Guid) : IRequest<AuthorDto>;

        public class Handler : IRequestHandler<Query, AuthorDto>
        {
            private readonly AuthorContext _context;
            private readonly IMapper _mapper;
            public Handler(AuthorContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<AuthorDto> Handle(Query request, CancellationToken cancellationToken)
            {
                return _mapper.Map<BookAuthor, AuthorDto> (await _context.BookAuthors.Where(x => x.BookAuthorGuid == request.Guid).FirstOrDefaultAsync());
            }
        }
    }
}
