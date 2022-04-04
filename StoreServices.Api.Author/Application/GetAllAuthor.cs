using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Author.Model;
using StoreServices.Api.Author.Persistance;

namespace StoreServices.Api.Author.Application
{
    public class GetAllAuthor : IRequest<List<AuthorDto>> { }
    public class Handler : IRequestHandler<GetAllAuthor, List<AuthorDto>>
    {
        private readonly AuthorContext _context;
        private readonly IMapper _mapper;
            
        public Handler(AuthorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<AuthorDto>> Handle(GetAllAuthor request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<BookAuthor>, List<AuthorDto>> (await _context.BookAuthors.ToListAsync());
        }
    }
}
