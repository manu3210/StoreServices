using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Book.Model;
using StoreServices.Api.Book.Persistance;

namespace StoreServices.Api.Book.Application
{
    public class GetBookById
    {
        public record Query (Guid id) : IRequest<BookDto>;

        public class Handler : IRequestHandler<Query, BookDto>
        {
            private readonly BookContext _context;
            private readonly IMapper _mapper;

            public Handler(BookContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<BookDto> Handle(Query request, CancellationToken cancellationToken)
            {
                return _mapper.Map<BookMaterial, BookDto>(await _context.Books.Where(x => x.Id == request.id).FirstOrDefaultAsync());
            }
        }
    }
}
