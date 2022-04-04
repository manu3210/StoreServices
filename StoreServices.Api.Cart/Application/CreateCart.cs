using MediatR;
using StoreServices.Api.Cart.Model;
using StoreServices.Api.Cart.Persistance;


namespace StoreServices.Api.Cart.Application
{
    public class CreateCart
    {
        public record CreateCartRequest(DateTime SessionDate, List<string> ProductList) : IRequest<CartSession>;
        public class Handler : IRequestHandler<CreateCartRequest, CartSession>
        {
            private readonly CartContext _context;
            public Handler(CartContext context)
            {
                _context = context;
            }
            public async Task<CartSession> Handle(CreateCartRequest request, CancellationToken cancellationToken)
            {
                var cartSession = new CartSession
                {
                    Date = request.SessionDate
                };

                _context.CartSessions.Add(cartSession);

                await _context.SaveChangesAsync();

                var sessionId = cartSession.Id;

                foreach(var obj in request.ProductList)
                {
                    var detail = new CartDetail
                    {
                        Date = DateTime.Now,
                        CartSessionId = sessionId,
                        SelectedProduct = obj
                    };

                    _context.CartDetails.Add(detail);
                }

                await _context.SaveChangesAsync();

                return cartSession;
            }
        }

    }
}
