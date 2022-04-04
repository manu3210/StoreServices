using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Book.Model;
using StoreServices.Api.Book.Persistance;

namespace StoreServices.Api.Book.Application
{
    public class GetAllBooks : IRequest<List<BookDto>> { }
    public class Handler : IRequestHandler<GetAllBooks, List<BookDto>>
    {
        private readonly BookContext _context;
        private readonly IMapper _mapper;

        public Handler(BookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BookDto>> Handle(GetAllBooks request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<BookMaterial>, List<BookDto>>(await _context.Books.ToListAsync());
        }
    }
}
