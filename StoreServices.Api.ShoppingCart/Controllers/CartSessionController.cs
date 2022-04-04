using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreServices.Api.ShoppingCart.Application;

namespace StoreServices.Api.ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartSessionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartSessionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart(CreateCart.CreateCartCommand data)
        {
            return Ok(await _mediator.Send(data));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCart( int id)
        {
            var cart = await _mediator.Send(new GetCartSessionById.Query { Id = id });

            if(cart != null)
                return Ok(cart);

            return NotFound();
        }
    }
}
