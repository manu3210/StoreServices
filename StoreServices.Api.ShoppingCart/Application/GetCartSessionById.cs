using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.ShoppingCart.Persistance;
using StoreServices.Api.ShoppingCart.RemoteInterface;

namespace StoreServices.Api.ShoppingCart.Application
{
    public class GetCartSessionById 
    {
        public class Query : IRequest<CartDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, CartDto>
        {
            private readonly CartContext _context;
            private readonly IBookService _bookService;

            public Handler(CartContext context, IBookService bookService)
            {
                _context = context; 
                _bookService = bookService;
            }
            public async Task<CartDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var cartDetailDtoList = new List<CartDetailDto>();
                var cartSession = await _context.CartSessions.FirstOrDefaultAsync(x => x.Id == request.Id);
                if(cartSession == null)
                    return null;

                var cartDetail = await _context.CartDetails.Where(x => x.CartSessionId == request.Id).ToListAsync();

                foreach (var detail in cartDetail)
                {
                    var book = await _bookService.GetLibro(new Guid(detail.SelectedProduct));

                    var bookDetail = new CartDetailDto
                    {
                        BookTittle = book.Tittle,
                        BookPublicationDate = book.PublicationDate,
                        BookId = book.Id,
                    };

                    cartDetailDtoList.Add(bookDetail);
                }

                var cartDto = new CartDto
                {
                    Id = cartSession.Id,
                    SessionDate = cartSession.Date,
                    Details = cartDetailDtoList
                };

                return cartDto;
            }
        }
    }
}
