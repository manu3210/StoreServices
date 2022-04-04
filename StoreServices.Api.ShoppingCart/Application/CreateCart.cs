using MediatR;
using StoreServices.Api.ShoppingCart.Model;
using StoreServices.Api.ShoppingCart.Persistance;

namespace StoreServices.Api.ShoppingCart.Application
{
    public class CreateCart
    {
        public class CreateCartCommand : IRequest<CartSession>
        {
            public DateTime Date { get; set; }
            public List<string> Details { get; set; }
        }

        public class Handler : IRequestHandler<CreateCartCommand, CartSession>
        {
            private readonly CartContext _context;

            public Handler(CartContext context)
            {
                _context = context;
            }
            public async Task<CartSession> Handle(CreateCartCommand request, CancellationToken cancellationToken)
            {
                var cartSession = new CartSession
                {
                    Date = request.Date
                };

                _context.CartSessions.Add(cartSession);
                var value = await _context.SaveChangesAsync();

                if (value == 0)
                    throw new Exception("Error adding CartSession");

                foreach(var item in request.Details)
                {
                    var detail = new CartDetail
                    {
                        Date = DateTime.Now,
                        CartSessionId = cartSession.Id,
                        SelectedProduct = item
                    };

                    _context.CartDetails.Add(detail);
                }

                await _context.SaveChangesAsync();

                return cartSession;
            }
        }
    }
}
